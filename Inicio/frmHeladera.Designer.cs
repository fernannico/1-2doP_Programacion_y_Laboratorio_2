
namespace Inicio
{
    partial class frmHeladera
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
            lblHeladera = new Label();
            btnModificar = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            txtModifCorte = new TextBox();
            txtModDescripcion = new TextBox();
            nudModifStock = new NumericUpDown();
            nudModifPrecio = new NumericUpDown();
            lblModifPrecio = new Label();
            lblModifStock = new Label();
            lblModifCorte = new Label();
            lblModifDescripcion = new Label();
            groupBox1 = new GroupBox();
            btnEliminar = new Button();
            btnDetalles = new Button();
            btnVender = new Button();
            comboBoxClientes = new ComboBox();
            label2 = new Label();
            btcFacturasHistorial = new Button();
            btnSerializar = new Button();
            btnCrearProd = new Button();
            btnDeserializarXml = new Button();
            lblGrados = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudModifStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudModifPrecio).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeladera
            // 
            lblHeladera.AutoSize = true;
            lblHeladera.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lblHeladera.Location = new Point(8, 50);
            lblHeladera.Name = "lblHeladera";
            lblHeladera.Size = new Size(74, 28);
            lblHeladera.TabIndex = 0;
            lblHeladera.Text = "STOCK";
            // 
            // btnModificar
            // 
            btnModificar.Enabled = false;
            btnModificar.Location = new Point(18, 292);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(230, 29);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.Desktop;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(8, 89);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(490, 352);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.Location = new Point(544, 37);
            label1.Name = "label1";
            label1.Size = new Size(196, 28);
            label1.TabIndex = 4;
            label1.Text = "Modificar producto";
            // 
            // txtModifCorte
            // 
            txtModifCorte.Location = new Point(18, 104);
            txtModifCorte.Name = "txtModifCorte";
            txtModifCorte.Size = new Size(230, 27);
            txtModifCorte.TabIndex = 5;
            // 
            // txtModDescripcion
            // 
            txtModDescripcion.Location = new Point(18, 51);
            txtModDescripcion.Name = "txtModDescripcion";
            txtModDescripcion.Size = new Size(230, 27);
            txtModDescripcion.TabIndex = 6;
            // 
            // nudModifStock
            // 
            nudModifStock.Location = new Point(18, 157);
            nudModifStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudModifStock.Name = "nudModifStock";
            nudModifStock.Size = new Size(230, 27);
            nudModifStock.TabIndex = 7;
            nudModifStock.Tag = "$";
            // 
            // nudModifPrecio
            // 
            nudModifPrecio.Location = new Point(18, 210);
            nudModifPrecio.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudModifPrecio.Name = "nudModifPrecio";
            nudModifPrecio.Size = new Size(230, 27);
            nudModifPrecio.TabIndex = 8;
            nudModifPrecio.Tag = "";
            // 
            // lblModifPrecio
            // 
            lblModifPrecio.AutoSize = true;
            lblModifPrecio.Location = new Point(18, 187);
            lblModifPrecio.Name = "lblModifPrecio";
            lblModifPrecio.Size = new Size(119, 20);
            lblModifPrecio.TabIndex = 9;
            lblModifPrecio.Text = "Modificar precio";
            // 
            // lblModifStock
            // 
            lblModifStock.AutoSize = true;
            lblModifStock.Location = new Point(18, 134);
            lblModifStock.Name = "lblModifStock";
            lblModifStock.Size = new Size(198, 20);
            lblModifStock.TabIndex = 10;
            lblModifStock.Text = "Reponer stock (agregar kg's)";
            // 
            // lblModifCorte
            // 
            lblModifCorte.AutoSize = true;
            lblModifCorte.Location = new Point(18, 81);
            lblModifCorte.Name = "lblModifCorte";
            lblModifCorte.Size = new Size(188, 20);
            lblModifCorte.TabIndex = 11;
            lblModifCorte.Text = "Modificar nombre de corte";
            // 
            // lblModifDescripcion
            // 
            lblModifDescripcion.AutoSize = true;
            lblModifDescripcion.Location = new Point(18, 28);
            lblModifDescripcion.Name = "lblModifDescripcion";
            lblModifDescripcion.Size = new Size(204, 20);
            lblModifDescripcion.TabIndex = 12;
            lblModifDescripcion.Text = "Modificar descripcion/animal";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnDetalles);
            groupBox1.Controls.Add(lblModifDescripcion);
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(lblModifCorte);
            groupBox1.Controls.Add(txtModifCorte);
            groupBox1.Controls.Add(lblModifStock);
            groupBox1.Controls.Add(txtModDescripcion);
            groupBox1.Controls.Add(lblModifPrecio);
            groupBox1.Controls.Add(nudModifStock);
            groupBox1.Controls.Add(nudModifPrecio);
            groupBox1.Location = new Point(518, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(265, 366);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "----------------------------------------";
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(18, 327);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(230, 29);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnDetalles
            // 
            btnDetalles.Enabled = false;
            btnDetalles.Location = new Point(18, 257);
            btnDetalles.Name = "btnDetalles";
            btnDetalles.Size = new Size(230, 29);
            btnDetalles.TabIndex = 13;
            btnDetalles.Text = "Ver detalles";
            btnDetalles.UseVisualStyleBackColor = true;
            btnDetalles.Click += button1_Click;
            // 
            // btnVender
            // 
            btnVender.Enabled = false;
            btnVender.ForeColor = Color.FromArgb(0, 64, 0);
            btnVender.Location = new Point(321, 447);
            btnVender.Name = "btnVender";
            btnVender.Size = new Size(152, 29);
            btnVender.TabIndex = 15;
            btnVender.Text = "Vender";
            btnVender.UseVisualStyleBackColor = true;
            btnVender.Click += btnVender_Click;
            // 
            // comboBoxClientes
            // 
            comboBoxClientes.BackColor = Color.Aquamarine;
            comboBoxClientes.FormattingEnabled = true;
            comboBoxClientes.Location = new Point(109, 447);
            comboBoxClientes.Name = "comboBoxClientes";
            comboBoxClientes.Size = new Size(206, 28);
            comboBoxClientes.TabIndex = 16;
            comboBoxClientes.SelectedIndexChanged += comboBoxClientes_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 451);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 17;
            label2.Text = "Elegir cliente";
            // 
            // btcFacturasHistorial
            // 
            btcFacturasHistorial.Enabled = false;
            btcFacturasHistorial.Location = new Point(536, 443);
            btcFacturasHistorial.Name = "btcFacturasHistorial";
            btcFacturasHistorial.Size = new Size(230, 29);
            btcFacturasHistorial.TabIndex = 18;
            btcFacturasHistorial.Text = "Ver historial de facturas";
            btcFacturasHistorial.UseVisualStyleBackColor = true;
            btcFacturasHistorial.Click += btcFacturasHistorial_Click;
            // 
            // btnSerializar
            // 
            btnSerializar.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            btnSerializar.Location = new Point(91, 30);
            btnSerializar.Name = "btnSerializar";
            btnSerializar.Size = new Size(136, 48);
            btnSerializar.TabIndex = 19;
            btnSerializar.Text = "Guardar estado stock (xml)";
            btnSerializar.UseVisualStyleBackColor = true;
            btnSerializar.Click += btnSerializar_Click;
            // 
            // btnCrearProd
            // 
            btnCrearProd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCrearProd.Location = new Point(379, 30);
            btnCrearProd.Name = "btnCrearProd";
            btnCrearProd.Size = new Size(94, 48);
            btnCrearProd.TabIndex = 20;
            btnCrearProd.Text = "Crear producto";
            btnCrearProd.UseVisualStyleBackColor = true;
            btnCrearProd.Click += btnCrearProd_Click;
            // 
            // btnDeserializarXml
            // 
            btnDeserializarXml.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeserializarXml.Location = new Point(233, 29);
            btnDeserializarXml.Name = "btnDeserializarXml";
            btnDeserializarXml.Size = new Size(140, 49);
            btnDeserializarXml.TabIndex = 21;
            btnDeserializarXml.Text = "Mostrar ultimo estado stock (xml)";
            btnDeserializarXml.UseVisualStyleBackColor = true;
            btnDeserializarXml.Click += btnDeserializarXml_Click;
            // 
            // lblGrados
            // 
            lblGrados.AutoSize = true;
            lblGrados.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblGrados.Location = new Point(544, -4);
            lblGrados.Name = "lblGrados";
            lblGrados.Size = new Size(70, 28);
            lblGrados.TabIndex = 22;
            lblGrados.Text = "label3";
            // 
            // frmHeladera
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(823, 485);
            Controls.Add(lblGrados);
            Controls.Add(btnDeserializarXml);
            Controls.Add(btnCrearProd);
            Controls.Add(btnSerializar);
            Controls.Add(btcFacturasHistorial);
            Controls.Add(label2);
            Controls.Add(comboBoxClientes);
            Controls.Add(btnVender);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(lblHeladera);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmHeladera";
            Text = "Bienvenido ";
            Load += frmHeladera_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudModifStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudModifPrecio).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeladera;
        private Button btnModificar;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox txtModifCorte;
        private TextBox txtModDescripcion;
        private NumericUpDown nudModifStock;
        private NumericUpDown nudModifPrecio;
        private Label lblModifPrecio;
        private Label lblModifStock;
        private Label lblModifCorte;
        private Label lblModifDescripcion;
        private GroupBox groupBox1;
        private Button btnDetalles;
        private Button btnVender;
        private ComboBox comboBoxClientes;
        private Label label2;
        private Button btcFacturasHistorial;
        private Button btnEliminar;
        private Button btnSerializar;
        private Button btnCrearProd;
        private Button btnDeserializarXml;
        private Label lblGrados;
    }
}