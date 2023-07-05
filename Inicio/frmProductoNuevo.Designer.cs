namespace Inicio
{
    partial class frmProductoNuevo
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
            txtDescripcion = new TextBox();
            txtCorte = new TextBox();
            NudStock = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            NudPrecio = new NumericUpDown();
            btnCrearOk = new Button();
            comboBoxTipoProd = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)NudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NudPrecio).BeginInit();
            SuspendLayout();
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(12, 99);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.PlaceholderText = "Descripcion";
            txtDescripcion.Size = new Size(150, 27);
            txtDescripcion.TabIndex = 1;
            // 
            // txtCorte
            // 
            txtCorte.Enabled = false;
            txtCorte.Location = new Point(178, 99);
            txtCorte.Name = "txtCorte";
            txtCorte.PlaceholderText = "Corte";
            txtCorte.Size = new Size(150, 27);
            txtCorte.TabIndex = 2;
            // 
            // NudStock
            // 
            NudStock.Location = new Point(178, 56);
            NudStock.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            NudStock.Name = "NudStock";
            NudStock.Size = new Size(151, 27);
            NudStock.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.GradientActiveCaption;
            label1.Location = new Point(178, 19);
            label1.Name = "label1";
            label1.Size = new Size(127, 28);
            label1.TabIndex = 4;
            label1.Text = "Stock inicial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.GradientActiveCaption;
            label2.Location = new Point(352, 19);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 5;
            label2.Text = "Precio por kg";
            // 
            // NudPrecio
            // 
            NudPrecio.Location = new Point(352, 56);
            NudPrecio.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NudPrecio.Name = "NudPrecio";
            NudPrecio.Size = new Size(150, 27);
            NudPrecio.TabIndex = 6;
            // 
            // btnCrearOk
            // 
            btnCrearOk.Location = new Point(352, 97);
            btnCrearOk.Name = "btnCrearOk";
            btnCrearOk.Size = new Size(150, 29);
            btnCrearOk.TabIndex = 7;
            btnCrearOk.Text = "Crear";
            btnCrearOk.UseVisualStyleBackColor = true;
            btnCrearOk.Click += btnCrearOk_Click;
            // 
            // comboBoxTipoProd
            // 
            comboBoxTipoProd.FormattingEnabled = true;
            comboBoxTipoProd.Location = new Point(12, 56);
            comboBoxTipoProd.Name = "comboBoxTipoProd";
            comboBoxTipoProd.Size = new Size(151, 28);
            comboBoxTipoProd.TabIndex = 8;
            comboBoxTipoProd.SelectedIndexChanged += comboBoxTipoProd_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.GradientActiveCaption;
            label3.Location = new Point(12, 19);
            label3.Name = "label3";
            label3.Size = new Size(146, 28);
            label3.TabIndex = 9;
            label3.Text = "Tipo producto";
            // 
            // frmProductoNuevo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SaddleBrown;
            ClientSize = new Size(517, 152);
            Controls.Add(label3);
            Controls.Add(comboBoxTipoProd);
            Controls.Add(btnCrearOk);
            Controls.Add(NudPrecio);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NudStock);
            Controls.Add(txtCorte);
            Controls.Add(txtDescripcion);
            Name = "frmProductoNuevo";
            Text = "Herramienta creacion producto";
            Load += frmProductoNuevo_Load;
            ((System.ComponentModel.ISupportInitialize)NudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)NudPrecio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtDescripcion;
        private TextBox txtCorte;
        private NumericUpDown NudStock;
        private Label label1;
        private Label label2;
        private NumericUpDown NudPrecio;
        private Button btnCrearOk;
        private ComboBox comboBoxTipoProd;
        private Label label3;
    }
}