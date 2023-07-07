namespace Inicio
{
    partial class frmHistorialFacturas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnDetalle = new Button();
            btnSaveFact = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = Color.DarkKhaki;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(45, 45);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(679, 309);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnDetalle
            // 
            btnDetalle.Enabled = false;
            btnDetalle.FlatAppearance.BorderColor = Color.White;
            btnDetalle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDetalle.ForeColor = SystemColors.ControlText;
            btnDetalle.Location = new Point(45, 364);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(278, 55);
            btnDetalle.TabIndex = 1;
            btnDetalle.Text = "ver detalle de la factura";
            btnDetalle.UseVisualStyleBackColor = true;
            btnDetalle.Click += btnDetalle_Click;
            // 
            // btnSaveFact
            // 
            btnSaveFact.Enabled = false;
            btnSaveFact.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveFact.Location = new Point(339, 364);
            btnSaveFact.Name = "btnSaveFact";
            btnSaveFact.Size = new Size(151, 55);
            btnSaveFact.TabIndex = 1;
            btnSaveFact.Text = "Guardar factura";
            btnSaveFact.UseVisualStyleBackColor = true;
            btnSaveFact.Click += btnSaveFact_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(505, 364);
            button1.Name = "button1";
            button1.Size = new Size(219, 55);
            button1.TabIndex = 2;
            button1.Text = "Ver historial de facturas guardadas";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmHistorialFacturas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOliveGreen;
            ClientSize = new Size(747, 445);
            Controls.Add(button1);
            Controls.Add(btnSaveFact);
            Controls.Add(btnDetalle);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "frmHistorialFacturas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de facturas actuales";
            Load += frmHistorialFacturas_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnDetalle;
        private Button btnSaveFact;
        private Button button1;
    }
}