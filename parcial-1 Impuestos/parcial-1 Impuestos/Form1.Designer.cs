namespace parcial_1_Impuestos
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.btnVerDesarrollo = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtMontoActividad = new System.Windows.Forms.TextBox();
            this.txtImpuestoPagar = new System.Windows.Forms.TextBox();
            this.lblImpuestoPagar = new System.Windows.Forms.Label();
            this.lblMontoActividad = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVerDesarrollo
            // 
            this.btnVerDesarrollo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDesarrollo.Location = new System.Drawing.Point(274, 150);
            this.btnVerDesarrollo.Name = "btnVerDesarrollo";
            this.btnVerDesarrollo.Size = new System.Drawing.Size(156, 32);
            this.btnVerDesarrollo.TabIndex = 19;
            this.btnVerDesarrollo.Text = "Ver calculo";
            this.btnVerDesarrollo.UseVisualStyleBackColor = true;
            this.btnVerDesarrollo.Click += new System.EventHandler(this.btnVerDesarrollo_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(131, 150);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(104, 32);
            this.btnCalcular.TabIndex = 18;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtMontoActividad
            // 
            this.txtMontoActividad.Location = new System.Drawing.Point(418, 105);
            this.txtMontoActividad.Name = "txtMontoActividad";
            this.txtMontoActividad.Size = new System.Drawing.Size(100, 22);
            this.txtMontoActividad.TabIndex = 17;
            // 
            // txtImpuestoPagar
            // 
            this.txtImpuestoPagar.Location = new System.Drawing.Point(296, 212);
            this.txtImpuestoPagar.Multiline = true;
            this.txtImpuestoPagar.Name = "txtImpuestoPagar";
            this.txtImpuestoPagar.ReadOnly = true;
            this.txtImpuestoPagar.Size = new System.Drawing.Size(100, 25);
            this.txtImpuestoPagar.TabIndex = 16;
            // 
            // lblImpuestoPagar
            // 
            this.lblImpuestoPagar.AutoSize = true;
            this.lblImpuestoPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpuestoPagar.Location = new System.Drawing.Point(74, 212);
            this.lblImpuestoPagar.Name = "lblImpuestoPagar";
            this.lblImpuestoPagar.Size = new System.Drawing.Size(190, 20);
            this.lblImpuestoPagar.TabIndex = 15;
            this.lblImpuestoPagar.Text = "Impuesto a pagar ($):";
            // 
            // lblMontoActividad
            // 
            this.lblMontoActividad.AutoSize = true;
            this.lblMontoActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoActividad.Location = new System.Drawing.Point(50, 105);
            this.lblMontoActividad.Name = "lblMontoActividad";
            this.lblMontoActividad.Size = new System.Drawing.Size(320, 20);
            this.lblMontoActividad.TabIndex = 14;
            this.lblMontoActividad.Text = "Monto de la actividad económica ($):";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(146, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 30);
            this.button1.TabIndex = 20;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(274, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 30);
            this.button2.TabIndex = 21;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Impuesto a las Actividades Economicas";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVerDesarrollo);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtMontoActividad);
            this.Controls.Add(this.txtImpuestoPagar);
            this.Controls.Add(this.lblImpuestoPagar);
            this.Controls.Add(this.lblMontoActividad);
            this.Name = "Form1";
            this.Text = "Impuestos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerDesarrollo;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.TextBox txtMontoActividad;
        private System.Windows.Forms.TextBox txtImpuestoPagar;
        private System.Windows.Forms.Label lblImpuestoPagar;
        private System.Windows.Forms.Label lblMontoActividad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}
