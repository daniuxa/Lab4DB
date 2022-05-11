namespace Lab4DBForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.ScalarButton = new System.Windows.Forms.Button();
            this.ProcedureButton = new System.Windows.Forms.Button();
            this.DataReaderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(260, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(528, 426);
            this.dataGridView1.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 25);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(95, 31);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(12, 75);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(95, 31);
            this.UpdateButton.TabIndex = 3;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(12, 132);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(95, 31);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // RollbackButton
            // 
            this.RollbackButton.Location = new System.Drawing.Point(12, 188);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(95, 31);
            this.RollbackButton.TabIndex = 6;
            this.RollbackButton.Text = "Rollback";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // ScalarButton
            // 
            this.ScalarButton.Location = new System.Drawing.Point(12, 240);
            this.ScalarButton.Name = "ScalarButton";
            this.ScalarButton.Size = new System.Drawing.Size(95, 31);
            this.ScalarButton.TabIndex = 7;
            this.ScalarButton.Text = "Scalar";
            this.ScalarButton.UseVisualStyleBackColor = true;
            this.ScalarButton.Click += new System.EventHandler(this.ScalarButton_Click);
            // 
            // ProcedureButton
            // 
            this.ProcedureButton.Location = new System.Drawing.Point(12, 296);
            this.ProcedureButton.Name = "ProcedureButton";
            this.ProcedureButton.Size = new System.Drawing.Size(95, 31);
            this.ProcedureButton.TabIndex = 8;
            this.ProcedureButton.Text = "Procedure";
            this.ProcedureButton.UseVisualStyleBackColor = true;
            this.ProcedureButton.Click += new System.EventHandler(this.ProcedureButton_Click);
            // 
            // DataReaderButton
            // 
            this.DataReaderButton.Location = new System.Drawing.Point(12, 348);
            this.DataReaderButton.Name = "DataReaderButton";
            this.DataReaderButton.Size = new System.Drawing.Size(95, 31);
            this.DataReaderButton.TabIndex = 9;
            this.DataReaderButton.Text = "DataReader";
            this.DataReaderButton.UseVisualStyleBackColor = true;
            this.DataReaderButton.Click += new System.EventHandler(this.DataReaderButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataReaderButton);
            this.Controls.Add(this.ProcedureButton);
            this.Controls.Add(this.ScalarButton);
            this.Controls.Add(this.RollbackButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.Button ScalarButton;
        private System.Windows.Forms.Button ProcedureButton;
        private System.Windows.Forms.Button DataReaderButton;
    }
}

