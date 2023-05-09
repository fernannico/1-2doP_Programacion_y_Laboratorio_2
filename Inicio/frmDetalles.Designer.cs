namespace Inicio
{
    partial class frmDetalles
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
            lblDetalles = new Label();
            SuspendLayout();
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.Location = new Point(23, 25);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(50, 20);
            lblDetalles.TabIndex = 0;
            lblDetalles.Text = "label1";
            // 
            // frmDetalles
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(204, 156);
            Controls.Add(lblDetalles);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDetalles";
            Text = "frmDetalles";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDetalles;
    }
}