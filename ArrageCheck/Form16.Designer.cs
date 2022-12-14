namespace ArrageCheck
{
    partial class Form16
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
            this.tBContraseñaAdmin = new System.Windows.Forms.TextBox();
            this.lNombreAdmin = new System.Windows.Forms.Label();
            this.bCancelarAdmin = new System.Windows.Forms.Button();
            this.bCambiarAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tBContraseñaAdmin
            // 
            this.tBContraseñaAdmin.Location = new System.Drawing.Point(75, 14);
            this.tBContraseñaAdmin.Name = "tBContraseñaAdmin";
            this.tBContraseñaAdmin.Size = new System.Drawing.Size(174, 20);
            this.tBContraseñaAdmin.TabIndex = 16;
            // 
            // lNombreAdmin
            // 
            this.lNombreAdmin.AutoSize = true;
            this.lNombreAdmin.Location = new System.Drawing.Point(12, 17);
            this.lNombreAdmin.Name = "lNombreAdmin";
            this.lNombreAdmin.Size = new System.Drawing.Size(64, 13);
            this.lNombreAdmin.TabIndex = 15;
            this.lNombreAdmin.Text = "Contraseña:";
            // 
            // bCancelarAdmin
            // 
            this.bCancelarAdmin.Location = new System.Drawing.Point(15, 49);
            this.bCancelarAdmin.Name = "bCancelarAdmin";
            this.bCancelarAdmin.Size = new System.Drawing.Size(99, 23);
            this.bCancelarAdmin.TabIndex = 13;
            this.bCancelarAdmin.Text = "Cancelar";
            this.bCancelarAdmin.UseVisualStyleBackColor = true;
            this.bCancelarAdmin.Click += new System.EventHandler(this.bCancelarAdmin_Click);
            // 
            // bCambiarAdmin
            // 
            this.bCambiarAdmin.Location = new System.Drawing.Point(150, 49);
            this.bCambiarAdmin.Name = "bCambiarAdmin";
            this.bCambiarAdmin.Size = new System.Drawing.Size(99, 23);
            this.bCambiarAdmin.TabIndex = 14;
            this.bCambiarAdmin.Text = "Cambiar";
            this.bCambiarAdmin.UseVisualStyleBackColor = true;
            this.bCambiarAdmin.Click += new System.EventHandler(this.bCambiarAdmin_Click);
            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(261, 87);
            this.Controls.Add(this.tBContraseñaAdmin);
            this.Controls.Add(this.lNombreAdmin);
            this.Controls.Add(this.bCancelarAdmin);
            this.Controls.Add(this.bCambiarAdmin);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(277, 126);
            this.MinimumSize = new System.Drawing.Size(277, 126);
            this.Name = "Form16";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBContraseñaAdmin;
        public System.Windows.Forms.Label lNombreAdmin;
        private System.Windows.Forms.Button bCancelarAdmin;
        private System.Windows.Forms.Button bCambiarAdmin;
    }
}