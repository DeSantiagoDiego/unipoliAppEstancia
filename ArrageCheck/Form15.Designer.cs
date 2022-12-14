namespace ArrageCheck
{
    partial class Form15
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
            this.tBContraseña = new System.Windows.Forms.TextBox();
            this.lNombre = new System.Windows.Forms.Label();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bCambiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tBContraseña
            // 
            this.tBContraseña.Location = new System.Drawing.Point(75, 14);
            this.tBContraseña.Name = "tBContraseña";
            this.tBContraseña.Size = new System.Drawing.Size(174, 20);
            this.tBContraseña.TabIndex = 12;
            this.tBContraseña.TextChanged += new System.EventHandler(this.tBContraseña_TextChanged);
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Location = new System.Drawing.Point(12, 17);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(64, 13);
            this.lNombre.TabIndex = 11;
            this.lNombre.Text = "Contraseña:";
            this.lNombre.Click += new System.EventHandler(this.lNombre_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(15, 49);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(99, 23);
            this.bCancelar.TabIndex = 9;
            this.bCancelar.Text = "Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bCambiar
            // 
            this.bCambiar.Location = new System.Drawing.Point(150, 49);
            this.bCambiar.Name = "bCambiar";
            this.bCambiar.Size = new System.Drawing.Size(99, 23);
            this.bCambiar.TabIndex = 10;
            this.bCambiar.Text = "Cambiar";
            this.bCambiar.UseVisualStyleBackColor = true;
            this.bCambiar.Click += new System.EventHandler(this.bCambiar_Click);
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(261, 87);
            this.Controls.Add(this.tBContraseña);
            this.Controls.Add(this.lNombre);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bCambiar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(277, 126);
            this.MinimumSize = new System.Drawing.Size(277, 126);
            this.Name = "Form15";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contraseña";
            this.Load += new System.EventHandler(this.Form15_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBContraseña;
        public System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bCambiar;
    }
}