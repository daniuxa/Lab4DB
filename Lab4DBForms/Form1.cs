using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab4DBForms
{
    public partial class Form1 : Form
    {
        const string connectionString = "Server=DESKTOP-HAL50HT;Database=CarShowroom;Integrated Security=True;TrustServerCertificate=True;Pooling=true"; //Pooling=true      
        const string SelectClients = "SELECT * FROM Clients";
        const string FName = "Олег";
        const string MName = "Ігорович";
        const string LName = "Чорний";
        const string Phone = "(066) 435-13-21";
        const string Email = null;
        const string SearchPhone = "(066) 061-64-21";
        const string NewFName = "Микола";
        SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RollbackButton_Click(sender, e);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataSet dataSet = new DataSet();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand(SelectClients, connection, transaction);
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(dataSet);
                DataTable table = dataSet.Tables[0];

                DataRow row = table.NewRow();
                row["FName"] = FName;
                row["MName"] = MName;
                row["LName"] = LName;
                row["Phone"] = Phone;
                row["Email"] = (Email == null) ? DBNull.Value : Email;

                try
                {
                    table.Rows.Add(row);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    dataAdapter.Update(dataSet);
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    throw new Exception($"Sql expression (Add): {commandBuilder.GetInsertCommand().CommandText}\n\nRollback changes");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();                    
                }
            }      
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataSet dataSet = new DataSet();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand(SelectClients, connection, transaction);
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(dataSet);
                DataTable table = dataSet.Tables[0];

                foreach (DataRow dataRow in table.Rows)
                {
                    if ((string)dataRow["Phone"] == SearchPhone)
                    {
                        dataRow["FName"] = NewFName;
                        break;
                    }
                }

                try
                {
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    dataAdapter.Update(dataSet);
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                    throw new Exception($"Sql expression (Update): {commandBuilder.GetUpdateCommand().CommandText}\n\nRollback changes");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
            }
        }

        private void RollbackButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command;
                command = new SqlCommand(SelectClients, connection);
                dataAdapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataSet dataSet = new DataSet();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand(SelectClients, connection, transaction);
                dataAdapter.SelectCommand = command;

                dataAdapter.Fill(dataSet);
                DataTable table = dataSet.Tables[0];

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if ((string)table.Rows[i]["Phone"] == SearchPhone)
                    {
                        table.Rows[i].Delete();
                        break;
                    }
                }

                try
                {
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    dataAdapter.Update(dataSet);
                    dataSet.Clear();
                    throw new Exception($"Sql expression (Delete): {commandBuilder.GetDeleteCommand().CommandText}\n\nRollback changes");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }

            }
        }

        private void ScalarButton_Click(object sender, EventArgs e)
        {
            string CountClients = "SELECT COUNT(*) FROM Clients";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(CountClients, connection);
                try
                {
                    object Count = command.ExecuteScalar();
                    MessageBox.Show($"Count Clients: {Count}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ProcedureButton_Click(object sender, EventArgs e)
        {
            const string SqlProc = "MinMaxAutoPrice";
            const string brand = "BMW";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(SqlProc, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter MinPriceParam = new SqlParameter
                {
                    ParameterName = "@MinPrice",
                    SqlDbType = SqlDbType.Money,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(MinPriceParam);

                SqlParameter MaxPriceParam = new SqlParameter
                {
                    ParameterName = "@MaxPrice",
                    SqlDbType = SqlDbType.Money,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(MaxPriceParam);

                SqlParameter BrandParam = new SqlParameter
                {
                    ParameterName = "@Brand",
                    SqlDbType = SqlDbType.VarChar,
                    Value = brand
                };
                command.Parameters.Add(BrandParam);

                try
                {
                    command.ExecuteNonQuery();
                    object MinPrice = command.Parameters["@MinPrice"].Value;
                    object MaxPrice = command.Parameters["@MaxPrice"].Value;
                    MessageBox.Show($"Min price {brand}: {MinPrice}\nMax price {brand}: {MaxPrice}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void DataReaderButton_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
}
