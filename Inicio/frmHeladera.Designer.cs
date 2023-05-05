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
            SuspendLayout();
            // 
            // lblHeladera
            // 
            lblHeladera.AutoSize = true;
            lblHeladera.Location = new Point(50, 31);
            lblHeladera.Name = "lblHeladera";
            lblHeladera.Size = new Size(67, 20);
            lblHeladera.TabIndex = 0;
            lblHeladera.Text = "heladera";
            // 
            // frmHeladera
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblHeladera);
            Name = "frmHeladera";
            Text = "frmHeladera";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeladera;
    }
}