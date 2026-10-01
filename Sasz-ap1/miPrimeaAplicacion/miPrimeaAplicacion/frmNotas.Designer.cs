namespace miPrimeaAplicacion
{
    partial class frmNotas
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
            this.grdNotas = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.lblResultadoEstado = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblResultadoPromedio = new System.Windows.Forms.Label();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.txtNota3 = new System.Windows.Forms.TextBox();
            this.lblNota3 = new System.Windows.Forms.Label();
            this.txtNota2 = new System.Windows.Forms.TextBox();
            this.lblNota2 = new System.Windows.Forms.Label();
            this.txtNota1 = new System.Windows.Forms.TextBox();
            this.lblNota1 = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.lblMateria = new System.Windows.Forms.Label();
            this.cmbAlumno = new System.Windows.Forms.ComboBox();
            this.lblAlumno = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lab1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lab2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parcial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // grdNotas
            // 
            this.grdNotas.AllowUserToAddRows = false;
            this.grdNotas.AllowUserToDeleteRows = false;
            this.grdNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdNotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.materia,
            this.periodo,
            this.lab1,
            this.lab2,
            this.parcial,
            this.nf,
            this.estado,
            this.idDetalle});
            this.grdNotas.Location = new System.Drawing.Point(45, 173);
            this.grdNotas.Margin = new System.Windows.Forms.Padding(4);
            this.grdNotas.MultiSelect = false;
            this.grdNotas.Name = "grdNotas";
            this.grdNotas.ReadOnly = true;
            this.grdNotas.RowHeadersWidth = 51;
            this.grdNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdNotas.Size = new System.Drawing.Size(787, 246);
            this.grdNotas.TabIndex = 37;
            this.grdNotas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdNotas_CellContentClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(732, 118);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 31);
            this.btnGuardar.TabIndex = 36;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(622, 118);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(100, 31);
            this.btnCalcular.TabIndex = 35;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // lblResultadoEstado
            // 
            this.lblResultadoEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultadoEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoEstado.Location = new System.Drawing.Point(712, 75);
            this.lblResultadoEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultadoEstado.Name = "lblResultadoEstado";
            this.lblResultadoEstado.Size = new System.Drawing.Size(119, 28);
            this.lblResultadoEstado.TabIndex = 34;
            this.lblResultadoEstado.Text = "-";
            this.lblResultadoEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(618, 81);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(63, 17);
            this.lblEstado.TabIndex = 33;
            this.lblEstado.Text = "Estado:";
            // 
            // lblResultadoPromedio
            // 
            this.lblResultadoPromedio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResultadoPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoPromedio.Location = new System.Drawing.Point(712, 32);
            this.lblResultadoPromedio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultadoPromedio.Name = "lblResultadoPromedio";
            this.lblResultadoPromedio.Size = new System.Drawing.Size(79, 28);
            this.lblResultadoPromedio.TabIndex = 32;
            this.lblResultadoPromedio.Text = "0.0";
            this.lblResultadoPromedio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPromedio
            // 
            this.lblPromedio.AutoSize = true;
            this.lblPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromedio.Location = new System.Drawing.Point(618, 38);
            this.lblPromedio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(81, 17);
            this.lblPromedio.TabIndex = 31;
            this.lblPromedio.Text = "Promedio:";
            // 
            // txtNota3
            // 
            this.txtNota3.Location = new System.Drawing.Point(512, 120);
            this.txtNota3.Margin = new System.Windows.Forms.Padding(4);
            this.txtNota3.Name = "txtNota3";
            this.txtNota3.Size = new System.Drawing.Size(79, 22);
            this.txtNota3.TabIndex = 30;
            this.txtNota3.Text = "0";
            // 
            // lblNota3
            // 
            this.lblNota3.AutoSize = true;
            this.lblNota3.Location = new System.Drawing.Point(445, 124);
            this.lblNota3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNota3.Name = "lblNota3";
            this.lblNota3.Size = new System.Drawing.Size(49, 16);
            this.lblNota3.TabIndex = 29;
            this.lblNota3.Text = "Nota 3:";
            // 
            // txtNota2
            // 
            this.txtNota2.Location = new System.Drawing.Point(512, 77);
            this.txtNota2.Margin = new System.Windows.Forms.Padding(4);
            this.txtNota2.Name = "txtNota2";
            this.txtNota2.Size = new System.Drawing.Size(79, 22);
            this.txtNota2.TabIndex = 28;
            this.txtNota2.Text = "0";
            // 
            // lblNota2
            // 
            this.lblNota2.AutoSize = true;
            this.lblNota2.Location = new System.Drawing.Point(445, 81);
            this.lblNota2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNota2.Name = "lblNota2";
            this.lblNota2.Size = new System.Drawing.Size(49, 16);
            this.lblNota2.TabIndex = 27;
            this.lblNota2.Text = "Nota 2:";
            // 
            // txtNota1
            // 
            this.txtNota1.Location = new System.Drawing.Point(512, 34);
            this.txtNota1.Margin = new System.Windows.Forms.Padding(4);
            this.txtNota1.Name = "txtNota1";
            this.txtNota1.Size = new System.Drawing.Size(79, 22);
            this.txtNota1.TabIndex = 26;
            this.txtNota1.Text = "0";
            // 
            // lblNota1
            // 
            this.lblNota1.AutoSize = true;
            this.lblNota1.Location = new System.Drawing.Point(445, 38);
            this.lblNota1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNota1.Name = "lblNota1";
            this.lblNota1.Size = new System.Drawing.Size(49, 16);
            this.lblNota1.TabIndex = 25;
            this.lblNota1.Text = "Nota 1:";
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(125, 120);
            this.cmbPeriodo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(292, 24);
            this.cmbPeriodo.TabIndex = 24;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(45, 124);
            this.lblPeriodo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(58, 16);
            this.lblPeriodo.TabIndex = 23;
            this.lblPeriodo.Text = "Periodo:";
            // 
            // cmbMateria
            // 
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(125, 77);
            this.cmbMateria.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(292, 24);
            this.cmbMateria.TabIndex = 22;
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(45, 81);
            this.lblMateria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(55, 16);
            this.lblMateria.TabIndex = 21;
            this.lblMateria.Text = "Materia:";
            // 
            // cmbAlumno
            // 
            this.cmbAlumno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlumno.FormattingEnabled = true;
            this.cmbAlumno.Location = new System.Drawing.Point(125, 34);
            this.cmbAlumno.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAlumno.Name = "cmbAlumno";
            this.cmbAlumno.Size = new System.Drawing.Size(292, 24);
            this.cmbAlumno.TabIndex = 20;
            // 
            // lblAlumno
            // 
            this.lblAlumno.AutoSize = true;
            this.lblAlumno.Location = new System.Drawing.Point(45, 38);
            this.lblAlumno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlumno.Name = "lblAlumno";
            this.lblAlumno.Size = new System.Drawing.Size(55, 16);
            this.lblAlumno.TabIndex = 19;
            this.lblAlumno.Text = "Alumno:";
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Alumno";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 125;
            // 
            // materia
            // 
            this.materia.HeaderText = "Materia";
            this.materia.MinimumWidth = 6;
            this.materia.Name = "materia";
            this.materia.ReadOnly = true;
            this.materia.Width = 125;
            // 
            // periodo
            // 
            this.periodo.HeaderText = "Período";
            this.periodo.MinimumWidth = 6;
            this.periodo.Name = "periodo";
            this.periodo.ReadOnly = true;
            this.periodo.Width = 125;
            // 
            // lab1
            // 
            this.lab1.HeaderText = "Nota 1 (30%)";
            this.lab1.MinimumWidth = 6;
            this.lab1.Name = "lab1";
            this.lab1.ReadOnly = true;
            this.lab1.Width = 125;
            // 
            // lab2
            // 
            this.lab2.HeaderText = "Nota 2 (30%)";
            this.lab2.MinimumWidth = 6;
            this.lab2.Name = "lab2";
            this.lab2.ReadOnly = true;
            this.lab2.Width = 125;
            // 
            // parcial
            // 
            this.parcial.HeaderText = "parcial";
            this.parcial.MinimumWidth = 6;
            this.parcial.Name = "parcial";
            this.parcial.ReadOnly = true;
            this.parcial.Width = 125;
            // 
            // nf
            // 
            this.nf.HeaderText = "Promedio";
            this.nf.MinimumWidth = 6;
            this.nf.Name = "nf";
            this.nf.ReadOnly = true;
            this.nf.Width = 125;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 125;
            // 
            // idDetalle
            // 
            this.idDetalle.HeaderText = "idDetalle";
            this.idDetalle.MinimumWidth = 6;
            this.idDetalle.Name = "idDetalle";
            this.idDetalle.ReadOnly = true;
            this.idDetalle.Width = 125;
            // 
            // frmNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.grdNotas);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblResultadoEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblResultadoPromedio);
            this.Controls.Add(this.lblPromedio);
            this.Controls.Add(this.txtNota3);
            this.Controls.Add(this.lblNota3);
            this.Controls.Add(this.txtNota2);
            this.Controls.Add(this.lblNota2);
            this.Controls.Add(this.txtNota1);
            this.Controls.Add(this.lblNota1);
            this.Controls.Add(this.cmbPeriodo);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.lblMateria);
            this.Controls.Add(this.cmbAlumno);
            this.Controls.Add(this.lblAlumno);
            this.Name = "frmNotas";
            this.Text = "Administración de Notas";
            this.Load += new System.EventHandler(this.frmNotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdNotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdNotas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label lblResultadoEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblResultadoPromedio;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.TextBox txtNota3;
        private System.Windows.Forms.Label lblNota3;
        private System.Windows.Forms.TextBox txtNota2;
        private System.Windows.Forms.Label lblNota2;
        private System.Windows.Forms.TextBox txtNota1;
        private System.Windows.Forms.Label lblNota1;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.ComboBox cmbAlumno;
        private System.Windows.Forms.Label lblAlumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lab1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lab2;
        private System.Windows.Forms.DataGridViewTextBoxColumn parcial;
        private System.Windows.Forms.DataGridViewTextBoxColumn nf;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalle;
    }
}