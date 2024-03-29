﻿namespace Inicio
{
    partial class frmVenta
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            listBoxProductos = new ListBox();
            lblCliente = new Label();
            lblMontoCliente = new Label();
            label1 = new Label();
            btnAgregar = new Button();
            label2 = new Label();
            nudKgs = new NumericUpDown();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            btnEliminar = new Button();
            txtTotal = new TextBox();
            btnComprar = new Button();
            comboBoxVendedores = new ComboBox();
            label4 = new Label();
            txtBuscador = new TextBox();
            listBoxHistorial = new ListBox();
            label6 = new Label();
            button1 = new Button();
            btnDeserializarJson = new Button();
            lblReloj = new Label();
            ((System.ComponentModel.ISupportInitialize)nudKgs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // listBoxProductos
            // 
            listBoxProductos.BackColor = Color.Salmon;
            listBoxProductos.FormattingEnabled = true;
            listBoxProductos.ItemHeight = 20;
            listBoxProductos.Location = new Point(18, 96);
            listBoxProductos.Name = "listBoxProductos";
            listBoxProductos.Size = new Size(291, 244);
            listBoxProductos.TabIndex = 0;
            listBoxProductos.SelectedIndexChanged += listBoxProductos_SelectedIndexChanged;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCliente.Location = new Point(479, 18);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(65, 28);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "label1";
            // 
            // lblMontoCliente
            // 
            lblMontoCliente.AutoSize = true;
            lblMontoCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMontoCliente.Location = new Point(421, 65);
            lblMontoCliente.Name = "lblMontoCliente";
            lblMontoCliente.Size = new Size(70, 28);
            lblMontoCliente.TabIndex = 2;
            lblMontoCliente.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.Location = new Point(18, 65);
            label1.Name = "label1";
            label1.Size = new Size(112, 28);
            label1.TabIndex = 3;
            label1.Text = "Productos:";
            // 
            // btnAgregar
            // 
            btnAgregar.Enabled = false;
            btnAgregar.ForeColor = Color.Black;
            btnAgregar.Location = new Point(160, 345);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(149, 29);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar al carrito";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(333, 65);
            label2.Name = "label2";
            label2.Size = new Size(82, 28);
            label2.TabIndex = 6;
            label2.Text = "Carrito:";
            // 
            // nudKgs
            // 
            nudKgs.DecimalPlaces = 2;
            nudKgs.Location = new Point(75, 346);
            nudKgs.Name = "nudKgs";
            nudKgs.Size = new Size(79, 27);
            nudKgs.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(18, 341);
            label3.Name = "label3";
            label3.Size = new Size(53, 28);
            label3.TabIndex = 8;
            label3.Text = "Kg's:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = Color.RosyBrown;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.MistyRose;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.MistyRose;
            dataGridView1.Location = new Point(333, 96);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = Color.MistyRose;
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(527, 244);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(333, 346);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(143, 29);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar del carrito";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(602, 346);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(125, 27);
            txtTotal.TabIndex = 11;
            txtTotal.Text = "Total:";
            // 
            // btnComprar
            // 
            btnComprar.Enabled = false;
            btnComprar.Location = new Point(733, 345);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(127, 29);
            btnComprar.TabIndex = 12;
            btnComprar.Text = "Comprar";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // comboBoxVendedores
            // 
            comboBoxVendedores.BackColor = Color.Silver;
            comboBoxVendedores.FormattingEnabled = true;
            comboBoxVendedores.Location = new Point(178, 18);
            comboBoxVendedores.Name = "comboBoxVendedores";
            comboBoxVendedores.Size = new Size(263, 28);
            comboBoxVendedores.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(18, 18);
            label4.Name = "label4";
            label4.Size = new Size(154, 28);
            label4.TabIndex = 14;
            label4.Text = "Elegir vendedor:";
            // 
            // txtBuscador
            // 
            txtBuscador.Location = new Point(136, 66);
            txtBuscador.Name = "txtBuscador";
            txtBuscador.Size = new Size(173, 27);
            txtBuscador.TabIndex = 15;
            txtBuscador.TextChanged += txtBuscador_TextChanged;
            // 
            // listBoxHistorial
            // 
            listBoxHistorial.BackColor = Color.MistyRose;
            listBoxHistorial.FormattingEnabled = true;
            listBoxHistorial.ItemHeight = 20;
            listBoxHistorial.Location = new Point(879, 96);
            listBoxHistorial.Name = "listBoxHistorial";
            listBoxHistorial.Size = new Size(210, 244);
            listBoxHistorial.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label6.Location = new Point(879, 50);
            label6.Name = "label6";
            label6.Size = new Size(179, 28);
            label6.TabIndex = 18;
            label6.Text = "Historial compras";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(18, 379);
            button1.Name = "button1";
            button1.Size = new Size(169, 29);
            button1.TabIndex = 19;
            button1.Text = "Guardar estado stock (J)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // btnDeserializarJson
            // 
            btnDeserializarJson.Location = new Point(193, 379);
            btnDeserializarJson.Name = "btnDeserializarJson";
            btnDeserializarJson.Size = new Size(222, 29);
            btnDeserializarJson.TabIndex = 20;
            btnDeserializarJson.Text = "Mostrar ultimo estado stock (J)";
            btnDeserializarJson.UseVisualStyleBackColor = true;
            btnDeserializarJson.Click += btnDeserializarJson_Click;
            // 
            // lblReloj
            // 
            lblReloj.AutoSize = true;
            lblReloj.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblReloj.Location = new Point(879, 9);
            lblReloj.Name = "lblReloj";
            lblReloj.Size = new Size(70, 28);
            lblReloj.TabIndex = 21;
            lblReloj.Text = "label5";
            // 
            // frmVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1101, 417);
            Controls.Add(lblReloj);
            Controls.Add(btnDeserializarJson);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(listBoxHistorial);
            Controls.Add(txtBuscador);
            Controls.Add(label4);
            Controls.Add(comboBoxVendedores);
            Controls.Add(btnComprar);
            Controls.Add(txtTotal);
            Controls.Add(btnEliminar);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(nudKgs);
            Controls.Add(label2);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(lblMontoCliente);
            Controls.Add(lblCliente);
            Controls.Add(listBoxProductos);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmVenta";
            Text = "frmVenta";
            FormClosing += frmVenta_FormClosing;
            Load += frmVenta_Load;
            ((System.ComponentModel.ISupportInitialize)nudKgs).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxProductos;
        private Label lblCliente;
        private Label lblMontoCliente;
        private Label label1;
        private Button btnAgregar;
        private Label label2;
        private NumericUpDown nudKgs;
        private Label label3;
        private DataGridView dataGridView1;
        private Button btnEliminar;
        private TextBox txtTotal;
        private Button btnComprar;
        private ComboBox comboBoxVendedores;
        private Label label4;
        private TextBox txtBuscador;
        private ListBox listBoxHistorial;
        private Label label6;
        private Button button1;
        private Button btnDeserializarJson;
        private Label lblReloj;
    }
}