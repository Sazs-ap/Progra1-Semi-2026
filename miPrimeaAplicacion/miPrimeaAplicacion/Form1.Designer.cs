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
            this.lblNum1 = new System.Windows.Forms.Label();
            this.txtNum1 = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtNum2 = new System.Windows.Forms.TextBox();
            this.lblNum2 = new System.Windows.Forms.Label();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.grbOpciones = new System.Windows.Forms.GroupBox();
            this.rdbSuma = new System.Windows.Forms.RadioButton();
            this.rdbResta = new System.Windows.Forms.RadioButton();
            this.rdbMultiplicacion = new System.Windows.Forms.RadioButton();
            this.rdbDivision = new System.Windows.Forms.RadioButton();
            this.rdbExponente = new System.Windows.Forms.RadioButton();
            this.rdbRaiz = new System.Windows.Forms.RadioButton();
            this.rdbFactorial = new System.Windows.Forms.RadioButton();
            this.cboOpciones = new System.Windows.Forms.ComboBox();
            this.lblOpciones = new System.Windows.Forms.Label();
            this.grbOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNum1
            // 
            this.lblNum1.AutoSize = true;
            this.lblNum1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum1.Location = new System.Drawing.Point(57, 84);
            this.lblNum1.Name = "lblNum1";
            this.lblNum1.Size = new System.Drawing.Size(64, 21);
            this.lblNum1.TabIndex = 0;
            this.lblNum1.Text = "Num 1:";
            // 
            // txtNum1
            // 
            this.txtNum1.Location = new System.Drawing.Point(127, 85);
            this.txtNum1.Name = "txtNum1";
            this.txtNum1.Size = new System.Drawing.Size(124, 20);
            this.txtNum1.TabIndex = 1;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(61, 239);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(190, 61);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtNum2
            // 
            this.txtNum2.Location = new System.Drawing.Point(127, 125);
            this.txtNum2.Name = "txtNum2";
            this.txtNum2.Size = new System.Drawing.Size(124, 20);
            this.txtNum2.TabIndex = 4;
            // 
            // lblNum2
            // 
            this.lblNum2.AutoSize = true;
            this.lblNum2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum2.Location = new System.Drawing.Point(57, 124);
            this.lblNum2.Name = "lblNum2";
            this.lblNum2.Size = new System.Drawing.Size(64, 21);
            this.lblNum2.TabIndex = 3;
            this.lblNum2.Text = "Num 2:";
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuesta.Location = new System.Drawing.Point(57, 179);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(104, 21);
            this.lblRespuesta.TabIndex = 5;
            this.lblRespuesta.Text = "Respuesta: ?";
            // 
            // grbOpciones
            // 
            this.grbOpciones.Controls.Add(this.rdbFactorial);
            this.grbOpciones.Controls.Add(this.rdbRaiz);
            this.grbOpciones.Controls.Add(this.rdbExponente);
            this.grbOpciones.Controls.Add(this.rdbDivision);
            this.grbOpciones.Controls.Add(this.rdbMultiplicacion);
            this.grbOpciones.Controls.Add(this.rdbResta);
            this.grbOpciones.Controls.Add(this.rdbSuma);
            this.grbOpciones.Location = new System.Drawing.Point(275, 70);
            this.grbOpciones.Name = "grbOpciones";
            this.grbOpciones.Size = new System.Drawing.Size(158, 230);
            this.grbOpciones.TabIndex = 6;
            this.grbOpciones.TabStop = false;
            this.grbOpciones.Text = "Opciones";
            // 
            // rdbSuma
            // 
            this.rdbSuma.AutoSize = true;
            this.rdbSuma.Checked = true;
            this.rdbSuma.Location = new System.Drawing.Point(22, 34);
            this.rdbSuma.Name = "rdbSuma";
            this.rdbSuma.Size = new System.Drawing.Size(52, 17);
            this.rdbSuma.TabIndex = 0;
            this.rdbSuma.TabStop = true;
            this.rdbSuma.Text = "Suma";
            this.rdbSuma.UseVisualStyleBackColor = true;
            // 
            // rdbResta
            // 
            this.rdbResta.AutoSize = true;
            this.rdbResta.Location = new System.Drawing.Point(22, 58);
            this.rdbResta.Name = "rdbResta";
            this.rdbResta.Size = new System.Drawing.Size(53, 17);
            this.rdbResta.TabIndex = 1;
            this.rdbResta.Text = "Resta";
            this.rdbResta.UseVisualStyleBackColor = true;
            // 
            // rdbMultiplicacion
            // 
            this.rdbMultiplicacion.AutoSize = true;
            this.rdbMultiplicacion.Location = new System.Drawing.Point(22, 81);
            this.rdbMultiplicacion.Name = "rdbMultiplicacion";
            this.rdbMultiplicacion.Size = new System.Drawing.Size(89, 17);
            this.rdbMultiplicacion.TabIndex = 2;
            this.rdbMultiplicacion.Text = "Multiplicacion";
            this.rdbMultiplicacion.UseVisualStyleBackColor = true;
            // 
            // rdbDivision
            // 
            this.rdbDivision.AutoSize = true;
            this.rdbDivision.Location = new System.Drawing.Point(22, 104);
            this.rdbDivision.Name = "rdbDivision";
            this.rdbDivision.Size = new System.Drawing.Size(62, 17);
            this.rdbDivision.TabIndex = 3;
            this.rdbDivision.Text = "Division";
            this.rdbDivision.UseVisualStyleBackColor = true;
            // 
            // rdbExponente
            // 
            this.rdbExponente.AutoSize = true;
            this.rdbExponente.Location = new System.Drawing.Point(22, 127);
            this.rdbExponente.Name = "rdbExponente";
            this.rdbExponente.Size = new System.Drawing.Size(76, 17);
            this.rdbExponente.TabIndex = 4;
            this.rdbExponente.Text = "Exponente";
            this.rdbExponente.UseVisualStyleBackColor = true;
            // 
            // rdbRaiz
            // 
            this.rdbRaiz.AutoSize = true;
            this.rdbRaiz.Location = new System.Drawing.Point(22, 150);
            this.rdbRaiz.Name = "rdbRaiz";
            this.rdbRaiz.Size = new System.Drawing.Size(46, 17);
            this.rdbRaiz.TabIndex = 5;
            this.rdbRaiz.Text = "Raiz";
            this.rdbRaiz.UseVisualStyleBackColor = true;
            // 
            // rdbFactorial
            // 
            this.rdbFactorial.AutoSize = true;
            this.rdbFactorial.Location = new System.Drawing.Point(22, 173);
            this.rdbFactorial.Name = "rdbFactorial";
            this.rdbFactorial.Size = new System.Drawing.Size(65, 17);
            this.rdbFactorial.TabIndex = 6;
            this.rdbFactorial.Text = "Factorial";
            this.rdbFactorial.UseVisualStyleBackColor = true;
            // 
            // cboOpciones
            // 
            this.cboOpciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOpciones.FormattingEnabled = true;
            this.cboOpciones.Items.AddRange(new object[] {
            "Suma",
            "Resta",
            "Multiplicacion",
            "Division",
            "Exponente",
            "Raiz",
            "Factorial"});
            this.cboOpciones.Location = new System.Drawing.Point(149, 28);
            this.cboOpciones.Name = "cboOpciones";
            this.cboOpciones.Size = new System.Drawing.Size(284, 21);
            this.cboOpciones.TabIndex = 7;
            // 
            // lblOpciones
            // 
            this.lblOpciones.AutoSize = true;
            this.lblOpciones.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpciones.Location = new System.Drawing.Point(57, 28);
            this.lblOpciones.Name = "lblOpciones";
            this.lblOpciones.Size = new System.Drawing.Size(86, 21);
            this.lblOpciones.TabIndex = 8;
            this.lblOpciones.Text = "Opciones:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 334);
            this.Controls.Add(this.lblOpciones);
            this.Controls.Add(this.cboOpciones);
            this.Controls.Add(this.grbOpciones);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.txtNum2);
            this.Controls.Add(this.lblNum2);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtNum1);
            this.Controls.Add(this.lblNum1);
            this.Name = "Form1";
            this.Text = "Calculadora basica";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbOpciones.ResumeLayout(false);
            this.grbOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNum1;
        private System.Windows.Forms.TextBox txtNum1;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.TextBox txtNum2;
        private System.Windows.Forms.Label lblNum2;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.GroupBox grbOpciones;
        private System.Windows.Forms.RadioButton rdbSuma;
        private System.Windows.Forms.RadioButton rdbFactorial;
        private System.Windows.Forms.RadioButton rdbRaiz;
        private System.Windows.Forms.RadioButton rdbExponente;
        private System.Windows.Forms.RadioButton rdbDivision;
        private System.Windows.Forms.RadioButton rdbMultiplicacion;
        private System.Windows.Forms.RadioButton rdbResta;
        private System.Windows.Forms.ComboBox cboOpciones;
        private System.Windows.Forms.Label lblOpciones;
    }
}

