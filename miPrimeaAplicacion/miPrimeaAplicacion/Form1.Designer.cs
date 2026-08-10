namespace miPrimeaAplicacion {
    partial class Form1 {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.lblTabla = new System.Windows.Forms.Label();
            this.txtTabla = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTabla
            // 
            this.lblTabla.AutoSize = true;
            this.lblTabla.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabla.Location = new System.Drawing.Point(27, 28);
            this.lblTabla.Name = "lblTabla";
            this.lblTabla.Size = new System.Drawing.Size(55, 21);
            this.lblTabla.TabIndex = 0;
            this.lblTabla.Text = "Tabla:";
            // 
            // txtTabla
            // 
            this.txtTabla.Location = new System.Drawing.Point(97, 29);
            this.txtTabla.Name = "txtTabla";
            this.txtTabla.Size = new System.Drawing.Size(124, 20);
            this.txtTabla.TabIndex = 1;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(31, 103);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(190, 61);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuesta.Location = new System.Drawing.Point(245, 29);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(104, 21);
            this.lblRespuesta.TabIndex = 5;
            this.lblRespuesta.Text = "Respuesta: ?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 194);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtTabla);
            this.Controls.Add(this.lblTabla);
            this.Name = "Form1";
            this.Text = "Calculadora basica";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTabla;
        private System.Windows.Forms.TextBox txtTabla;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblRespuesta;
    }
}

