namespace Inicio
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
            lblVenta = new Label();
            SuspendLayout();
            // 
            // lblVenta
            // 
            lblVenta.AutoSize = true;
            lblVenta.Location = new Point(42, 74);
            lblVenta.Name = "lblVenta";
            lblVenta.Size = new Size(63, 20);
            lblVenta.TabIndex = 0;
            lblVenta.Text = "lblVenta";
            // 
            // frmVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblVenta);
            Name = "frmVenta";
            Text = "frmVenta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVenta;
    }
}