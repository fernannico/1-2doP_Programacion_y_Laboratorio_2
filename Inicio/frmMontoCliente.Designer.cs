namespace Inicio
{
    partial class frmMontoCliente
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
            nudMontoCiente = new NumericUpDown();
            label1 = new Label();
            btnIngresar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudMontoCiente).BeginInit();
            SuspendLayout();
            // 
            // nudMontoCiente
            // 
            nudMontoCiente.BackColor = Color.YellowGreen;
            nudMontoCiente.Location = new Point(57, 55);
            nudMontoCiente.Maximum = new decimal(new int[] { 500000, 0, 0, 0 });
            nudMontoCiente.Name = "nudMontoCiente";
            nudMontoCiente.Size = new Size(200, 27);
            nudMontoCiente.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(290, 23);
            label1.TabIndex = 1;
            label1.Text = "Ingrese el monto maximo a gastar!";
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(80, 103);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(150, 29);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // frmMontoCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(317, 144);
            Controls.Add(btnIngresar);
            Controls.Add(label1);
            Controls.Add(nudMontoCiente);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMontoCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bienvenido!";
            ((System.ComponentModel.ISupportInitialize)nudMontoCiente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        public NumericUpDown nudMontoCiente;
        private Button btnIngresar;
    }
}