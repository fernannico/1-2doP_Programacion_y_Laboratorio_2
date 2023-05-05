namespace Inicio
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMail = new Label();
            lblContrasenia = new Label();
            btnIngresar = new Button();
            txtContrasenia = new TextBox();
            label3 = new Label();
            txtMail = new TextBox();
            listBox1 = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMail.Location = new Point(49, 65);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(54, 28);
            lblMail.TabIndex = 0;
            lblMail.Text = "Mail";
            // 
            // lblContrasenia
            // 
            lblContrasenia.AutoSize = true;
            lblContrasenia.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblContrasenia.Location = new Point(49, 142);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(118, 28);
            lblContrasenia.TabIndex = 1;
            lblContrasenia.Text = "Contraseña";
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(60, 231);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(94, 29);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(49, 173);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.PasswordChar = '*';
            txtContrasenia.Size = new Size(125, 27);
            txtContrasenia.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(37, 20);
            label3.Name = "label3";
            label3.Size = new Size(150, 32);
            label3.TabIndex = 5;
            label3.Text = "Bienvenido!";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(49, 96);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(125, 27);
            txtMail.TabIndex = 6;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(212, 96);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(242, 124);
            listBox1.TabIndex = 7;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(287, 68);
            label1.Name = "label1";
            label1.Size = new Size(77, 23);
            label1.TabIndex = 8;
            label1.Text = "Usuarios";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 283);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(txtMail);
            Controls.Add(label3);
            Controls.Add(txtContrasenia);
            Controls.Add(btnIngresar);
            Controls.Add(lblContrasenia);
            Controls.Add(lblMail);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLogin";
            Text = "Login";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMail;
        private Label lblContrasenia;
        private Button btnIngresar;
        private TextBox txtContrasenia;
        private Label label3;
        private TextBox txtMail;
        private ListBox listBox1;
        private Label label1;
    }
}