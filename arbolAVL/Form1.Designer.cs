namespace arbolAVL
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grafica = new System.Windows.Forms.PictureBox();
            this.insertar = new System.Windows.Forms.TextBox();
            this.eliminar = new System.Windows.Forms.TextBox();
            this.btninsertar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grafica)).BeginInit();
            this.SuspendLayout();
            // 
            // grafica
            // 
            this.grafica.Location = new System.Drawing.Point(21, 34);
            this.grafica.Name = "grafica";
            this.grafica.Size = new System.Drawing.Size(544, 492);
            this.grafica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.grafica.TabIndex = 0;
            this.grafica.TabStop = false;
            // 
            // insertar
            // 
            this.insertar.Location = new System.Drawing.Point(611, 57);
            this.insertar.Name = "insertar";
            this.insertar.Size = new System.Drawing.Size(44, 20);
            this.insertar.TabIndex = 1;
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(611, 150);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(44, 20);
            this.eliminar.TabIndex = 2;
            // 
            // btninsertar
            // 
            this.btninsertar.Location = new System.Drawing.Point(611, 84);
            this.btninsertar.Name = "btninsertar";
            this.btninsertar.Size = new System.Drawing.Size(224, 30);
            this.btninsertar.TabIndex = 3;
            this.btninsertar.Text = "Insertar";
            this.btninsertar.UseVisualStyleBackColor = true;
            this.btninsertar.Click += new System.EventHandler(this.btninsertar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(611, 190);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(224, 28);
            this.btneliminar.TabIndex = 4;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(874, 581);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btninsertar);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.insertar);
            this.Controls.Add(this.grafica);
            this.Name = "Form1";
            this.Text = "AVL";
            ((System.ComponentModel.ISupportInitialize)(this.grafica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox grafica;
        private System.Windows.Forms.TextBox insertar;
        private System.Windows.Forms.TextBox eliminar;
        private System.Windows.Forms.Button btninsertar;
        private System.Windows.Forms.Button btneliminar;
    }
}

