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
    public partial class Form2 : Form
    {
        const string connectionString = "Server=DESKTOP-HAL50HT;Database=CarShowroom;Integrated Security=True;TrustServerCertificate=True;Pooling=true"; //Pooling=true

        public Form2()
        {
            InitializeComponent();
        }

        private void ShowAllClientsButton_Click(object sender, EventArgs e)
        {
            ShowAllClients();
        }

        private void ShowAllClients(SqlTransaction transaction = null)
        {
            const string SelectClients = "SELECT * FROM Clients";
            SqlCommand command;

            if (transaction == null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    command = new SqlCommand(SelectClients, connection);

                    //Opening a reader for reading Clients table
                    using (SqlDataReader sqlDataReader = command.ExecuteReader())
                    {
                        Console.WriteLine($"{sqlDataReader.GetName(0)}\t\t\tName\t\t\t{sqlDataReader.GetName(4)}\t\t\t{sqlDataReader.GetName(5)}");
                        if (sqlDataReader.HasRows)
                        {
                            string Message = "";
                            while (sqlDataReader.Read())
                            {
                                int ID = sqlDataReader.GetInt32(0);
                                string Name = sqlDataReader.GetString(1) + " " + sqlDataReader.GetString(2) + " " + sqlDataReader.GetString(3);
                                string Phone = sqlDataReader.GetString(4);
                                string Email = sqlDataReader.IsDBNull(5) ? null : sqlDataReader.GetString(5);
                                Message += $"{ID} \t{Name} \t{Phone} \t{Email}\n";
                            }
                            MessageBox.Show(Message);
                        }
                    }
                }
            }
            else
            {
                SqlConnection connection = transaction.Connection;
                command = new SqlCommand(SelectClients, connection, transaction);

                //Opening a reader for reading Clients table
                using (SqlDataReader sqlDataReader = command.ExecuteReader())
                {
                    Console.WriteLine($"{sqlDataReader.GetName(0)}\t\t\tName\t\t\t{sqlDataReader.GetName(4)}\t\t\t{sqlDataReader.GetName(5)}");
                    if (sqlDataReader.HasRows)
                    {
                        string Message = "";
                        while (sqlDataReader.Read())
                        {
                            int ID = sqlDataReader.GetInt32(0);
                            string Name = sqlDataReader.GetString(1) + " " + sqlDataReader.GetString(2) + " " + sqlDataReader.GetString(3);
                            string Phone = sqlDataReader.GetString(4);
                            string Email = sqlDataReader.IsDBNull(5) ? null : sqlDataReader.GetString(5);
                            Message += $"{ID} \t{Name} \t{Phone} \t{Email}\n";
                        }
                        MessageBox.Show(Message);
                    }
                }
            }           
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            const string FName = "Олег";
            const string MName = "Ігорович";
            const string LName = "Чорний";
            const string Phone = "(066) 435-13-21";
            const string Email = null;
            const string InsertClients = @"INSERT INTO Clients
                                        (FName, MName, LName, Phone, Email) 
                                        VALUES
                                        (@FName, @MName, @LName, @Phone, @Email)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand(InsertClients, connection);

                SqlParameter FNameParameter = new SqlParameter("@FName", FName);
                FNameParameter.SqlDbType = SqlDbType.NVarChar;
                FNameParameter.Size = 30;
                command.Parameters.Add(FNameParameter);

                SqlParameter MNameParameter = new SqlParameter("@MName", MName);
                MNameParameter.SqlDbType = SqlDbType.NVarChar;
                MNameParameter.Size = 30;
                command.Parameters.Add(MNameParameter);

                SqlParameter LNameParameter = new SqlParameter("@LName", LName);
                LNameParameter.SqlDbType = SqlDbType.NVarChar;
                LNameParameter.Size = 30;
                command.Parameters.Add(LNameParameter);

                SqlParameter PhoneParameter = new SqlParameter("@Phone", Phone);
                PhoneParameter.SqlDbType = SqlDbType.Char;
                PhoneParameter.Size = 15;
                command.Parameters.Add(PhoneParameter);

                SqlParameter EmailParameter = new SqlParameter("@Email", (Email == null) ? DBNull.Value : Email);
                EmailParameter.SqlDbType = SqlDbType.Char;
                EmailParameter.Size = 30;
                EmailParameter.IsNullable = true;
                command.Parameters.Add(EmailParameter);
                command.Transaction = transaction;
                try
                {
                    int numberRows = command.ExecuteNonQuery();
                    MessageBox.Show($"\nAffected {numberRows} row(s)");
                    ShowAllClients(transaction);
                    throw new Exception("Rollback changes");
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
            string UpdateClientsFName = "UPDATE Clients SET FName = 'Микола' WHERE Phone = @Phone";
            string Phone = "(066) 061-64-21";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(UpdateClientsFName, connection);
                SqlTransaction transaction = connection.BeginTransaction();

                SqlParameter PhoneParameter = new SqlParameter("@Phone", Phone);
                PhoneParameter.SqlDbType = SqlDbType.Char;
                PhoneParameter.Size = 15;
                command.Parameters.Add(PhoneParameter);

                command.Transaction = transaction;
                try
                {
                    int numberRows = command.ExecuteNonQuery();
                    MessageBox.Show($"\nAffected {numberRows} row(s)");
                    ShowAllClients(transaction);
                    throw new Exception("Rollback changes");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string Phone = "(066) 061-64-21";
            string DeleteClients = "DELETE Clients WHERE Phone = @Phone";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DeleteClients, connection);
                SqlTransaction transaction = connection.BeginTransaction();
                SqlParameter PhoneParameter = new SqlParameter("@Phone", Phone);
                PhoneParameter.SqlDbType = SqlDbType.Char;
                PhoneParameter.Size = 15;
                command.Parameters.Add(PhoneParameter);

                command.Transaction = transaction;
                try
                {
                    int numberRows = command.ExecuteNonQuery();
                    MessageBox.Show($"\nAffected {numberRows} row(s)");
                    ShowAllClients(transaction);
                    throw new Exception("Rollback changes");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
            }
        }
    }
}
