
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
            btnDetalles = new Button();
            lblVendedorElegido = new Label();
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
            lblHeladera.Location = new Point(387, 13);
            lblHeladera.Name = "lblHeladera";
            lblHeladera.Size = new Size(74, 28);
            lblHeladera.TabIndex = 0;
            lblHeladera.Text = "STOCK";
            // 
            // btnModificar
            // 
            btnModificar.Enabled = false;
            btnModificar.Location = new Point(18, 311);
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
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(465, 352);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.Location = new Point(502, 13);
            label1.Name = "label1";
            label1.Size = new Size(196, 28);
            label1.TabIndex = 4;
            label1.Text = "Modificar producto";
            // 
            // txtModifCorte
            // 
            txtModifCorte.Location = new Point(18, 102);
            txtModifCorte.Name = "txtModifCorte";
            txtModifCorte.Size = new Size(230, 27);
            txtModifCorte.TabIndex = 5;
            // 
            // txtModDescripcion
            // 
            txtModDescripcion.Location = new Point(18, 46);
            txtModDescripcion.Name = "txtModDescripcion";
            txtModDescripcion.Size = new Size(230, 27);
            txtModDescripcion.TabIndex = 6;
            // 
            // nudModifStock
            // 
            nudModifStock.Location = new Point(18, 164);
            nudModifStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudModifStock.Name = "nudModifStock";
            nudModifStock.Size = new Size(230, 27);
            nudModifStock.TabIndex = 7;
            nudModifStock.Tag = "$";
            // 
            // nudModifPrecio
            // 
            nudModifPrecio.Location = new Point(18, 223);
            nudModifPrecio.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudModifPrecio.Name = "nudModifPrecio";
            nudModifPrecio.Size = new Size(230, 27);
            nudModifPrecio.TabIndex = 8;
            nudModifPrecio.Tag = "";
            // 
            // lblModifPrecio
            // 
            lblModifPrecio.AutoSize = true;
            lblModifPrecio.Location = new Point(18, 200);
            lblModifPrecio.Name = "lblModifPrecio";
            lblModifPrecio.Size = new Size(119, 20);
            lblModifPrecio.TabIndex = 9;
            lblModifPrecio.Text = "Modificar precio";
            // 
            // lblModifStock
            // 
            lblModifStock.AutoSize = true;
            lblModifStock.Location = new Point(18, 141);
            lblModifStock.Name = "lblModifStock";
            lblModifStock.Size = new Size(198, 20);
            lblModifStock.TabIndex = 10;
            lblModifStock.Text = "Reponer stock (agregar kg's)";
            // 
            // lblModifCorte
            // 
            lblModifCorte.AutoSize = true;
            lblModifCorte.Location = new Point(18, 79);
            lblModifCorte.Name = "lblModifCorte";
            lblModifCorte.Size = new Size(188, 20);
            lblModifCorte.TabIndex = 11;
            lblModifCorte.Text = "Modificar nombre de corte";
            // 
            // lblModifDescripcion
            // 
            lblModifDescripcion.AutoSize = true;
            lblModifDescripcion.Location = new Point(18, 23);
            lblModifDescripcion.Name = "lblModifDescripcion";
            lblModifDescripcion.Size = new Size(204, 20);
            lblModifDescripcion.TabIndex = 12;
            lblModifDescripcion.Text = "Modificar descripcion/animal";
            // 
            // groupBox1
            // 
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
            groupBox1.Location = new Point(502, 44);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(265, 352);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "----------------------------------------";
            // 
            // btnDetalles
            // 
            btnDetalles.Enabled = false;
            btnDetalles.Location = new Point(18, 266);
            btnDetalles.Name = "btnDetalles";
            btnDetalles.Size = new Size(230, 29);
            btnDetalles.TabIndex = 13;
            btnDetalles.Text = "Ver detalles";
            btnDetalles.UseVisualStyleBackColor = true;
            btnDetalles.Click += button1_Click;
            // 
            // lblVendedorElegido
            // 
            lblVendedorElegido.AutoSize = true;
            lblVendedorElegido.Location = new Point(90, 10);
            lblVendedorElegido.Name = "lblVendedorElegido";
            lblVendedorElegido.Size = new Size(50, 20);
            lblVendedorElegido.TabIndex = 14;
            lblVendedorElegido.Text = "label2";
            // 
            // frmHeladera
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 419);
            Controls.Add(lblVendedorElegido);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(lblHeladera);
            Name = "frmHeladera";
            Text = "frmHeladera";
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
        private Label lblVendedorElegido;
        private Button btnDetalles;
    }
}