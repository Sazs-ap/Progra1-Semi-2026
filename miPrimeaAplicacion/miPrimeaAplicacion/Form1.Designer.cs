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
            this.btnCalcular = new System.Windows.Forms.Button();
            this.ltsRespuesta = new System.Windows.Forms.ListBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(250, 204);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(190, 61);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // ltsRespuesta
            // 
            this.ltsRespuesta.FormattingEnabled = true;
            this.ltsRespuesta.Location = new System.Drawing.Point(54, 140);
            this.ltsRespuesta.Name = "ltsRespuesta";
            this.ltsRespuesta.Size = new System.Drawing.Size(165, 186);
            this.ltsRespuesta.TabIndex = 3;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(51, 73);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(34, 13);
            this.lblSerie.TabIndex = 4;
            this.lblSerie.Text = "Serie:";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(91, 73);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(243, 20);
            this.txtSerie.TabIndex = 5;
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Location = new System.Drawing.Point(51, 124);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(37, 13);
            this.lblRespuesta.TabIndex = 6;
            this.lblRespuesta.Text = "Pares:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 332);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblSerie);
            this.Controls.Add(this.ltsRespuesta);
            this.Controls.Add(this.btnCalcular);
            this.Name = "Form1";
            this.Text = "Conversor de Longitud";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.ListBox ltsRespuesta;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblRespuesta;
    }
}

