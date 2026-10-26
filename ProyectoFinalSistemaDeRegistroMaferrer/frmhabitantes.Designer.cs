namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    partial class frmhabitantes
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmhabitantes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdHabitantes = new System.Windows.Forms.DataGridView();
            this.txtBuscarHabitantes = new System.Windows.Forms.TextBox();
            this.grbDatosHabitante = new System.Windows.Forms.GroupBox();
            this.btnEliminarHabitante = new System.Windows.Forms.Button();
            this.btnModificarHabitante = new System.Windows.Forms.Button();
            this.btnAgregarHabitante = new System.Windows.Forms.Button();
            this.txtTelefonoHabitante = new System.Windows.Forms.TextBox();
            this.lblTelefonoHabitante = new System.Windows.Forms.Label();
            this.txtDireccionHabitante = new System.Windows.Forms.TextBox();
            this.lblDireccionHabitante = new System.Windows.Forms.Label();
            this.txtCodigoHabitante = new System.Windows.Forms.TextBox();
            this.lblCodigoHabitante = new System.Windows.Forms.Label();
            this.txtNombreHabitante = new System.Windows.Forms.TextBox();
            this.lblNombreHabitante = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.casa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHabitantes)).BeginInit();
            this.grbDatosHabitante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdHabitantes);
            this.groupBox1.Controls.Add(this.txtBuscarHabitantes);
            this.groupBox1.Location = new System.Drawing.Point(13, 120);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(722, 459);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda de habitantes";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // grdHabitantes
            // 
            this.grdHabitantes.AllowUserToAddRows = false;
            this.grdHabitantes.AllowUserToDeleteRows = false;
            this.grdHabitantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdHabitantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHabitantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.casa,
            this.direccion,
            this.telefono});
            this.grdHabitantes.Location = new System.Drawing.Point(7, 52);
            this.grdHabitantes.Name = "grdHabitantes";
            this.grdHabitantes.RowHeadersWidth = 51;
            this.grdHabitantes.RowTemplate.Height = 24;
            this.grdHabitantes.Size = new System.Drawing.Size(696, 280);
            this.grdHabitantes.TabIndex = 4;
            this.grdHabitantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdHabitantes_CellClick);
            this.grdHabitantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdHabitantes_CellContentClick);
            // 
            // txtBuscarHabitantes
            // 
            this.txtBuscarHabitantes.Location = new System.Drawing.Point(7, 23);
            this.txtBuscarHabitantes.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarHabitantes.Name = "txtBuscarHabitantes";
            this.txtBuscarHabitantes.Size = new System.Drawing.Size(696, 22);
            this.txtBuscarHabitantes.TabIndex = 1;
            this.txtBuscarHabitantes.TextChanged += new System.EventHandler(this.txtBuscarHabitantes_TextChanged);
            // 
            // grbDatosHabitante
            // 
            this.grbDatosHabitante.Controls.Add(this.btnEliminarHabitante);
            this.grbDatosHabitante.Controls.Add(this.btnModificarHabitante);
            this.grbDatosHabitante.Controls.Add(this.btnAgregarHabitante);
            this.grbDatosHabitante.Controls.Add(this.txtTelefonoHabitante);
            this.grbDatosHabitante.Controls.Add(this.lblTelefonoHabitante);
            this.grbDatosHabitante.Controls.Add(this.txtDireccionHabitante);
            this.grbDatosHabitante.Controls.Add(this.lblDireccionHabitante);
            this.grbDatosHabitante.Controls.Add(this.txtCodigoHabitante);
            this.grbDatosHabitante.Controls.Add(this.lblCodigoHabitante);
            this.grbDatosHabitante.Controls.Add(this.txtNombreHabitante);
            this.grbDatosHabitante.Controls.Add(this.lblNombreHabitante);
            this.grbDatosHabitante.Location = new System.Drawing.Point(762, 120);
            this.grbDatosHabitante.Margin = new System.Windows.Forms.Padding(4);
            this.grbDatosHabitante.Name = "grbDatosHabitante";
            this.grbDatosHabitante.Padding = new System.Windows.Forms.Padding(4);
            this.grbDatosHabitante.Size = new System.Drawing.Size(575, 418);
            this.grbDatosHabitante.TabIndex = 13;
            this.grbDatosHabitante.TabStop = false;
            this.grbDatosHabitante.Text = "Detalle del habitante";
            this.grbDatosHabitante.Enter += new System.EventHandler(this.grbDatosHabitante_Enter);
            // 
            // btnEliminarHabitante
            // 
            this.btnEliminarHabitante.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarHabitante.Location = new System.Drawing.Point(151, 318);
            this.btnEliminarHabitante.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarHabitante.Name = "btnEliminarHabitante";
            this.btnEliminarHabitante.Size = new System.Drawing.Size(195, 37);
            this.btnEliminarHabitante.TabIndex = 9;
            this.btnEliminarHabitante.Text = "Eliminar registro";
            this.btnEliminarHabitante.UseVisualStyleBackColor = true;
            this.btnEliminarHabitante.Click += new System.EventHandler(this.btnEliminarHabitante_Click);
            // 
            // btnModificarHabitante
            // 
            this.btnModificarHabitante.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarHabitante.Location = new System.Drawing.Point(266, 271);
            this.btnModificarHabitante.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificarHabitante.Name = "btnModificarHabitante";
            this.btnModificarHabitante.Size = new System.Drawing.Size(224, 37);
            this.btnModificarHabitante.TabIndex = 8;
            this.btnModificarHabitante.Text = "Actualizar registro";
            this.btnModificarHabitante.UseVisualStyleBackColor = true;
            this.btnModificarHabitante.Click += new System.EventHandler(this.btnModificarHabitante_Click);
            // 
            // btnAgregarHabitante
            // 
            this.btnAgregarHabitante.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarHabitante.Location = new System.Drawing.Point(51, 271);
            this.btnAgregarHabitante.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarHabitante.Name = "btnAgregarHabitante";
            this.btnAgregarHabitante.Size = new System.Drawing.Size(195, 37);
            this.btnAgregarHabitante.TabIndex = 7;
            this.btnAgregarHabitante.Text = "Nuevo registro";
            this.btnAgregarHabitante.UseVisualStyleBackColor = true;
            this.btnAgregarHabitante.Click += new System.EventHandler(this.btnAgregarHabitante_Click);
            // 
            // txtTelefonoHabitante
            // 
            this.txtTelefonoHabitante.Location = new System.Drawing.Point(140, 210);
            this.txtTelefonoHabitante.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefonoHabitante.Name = "txtTelefonoHabitante";
            this.txtTelefonoHabitante.Size = new System.Drawing.Size(260, 22);
            this.txtTelefonoHabitante.TabIndex = 7;
            // 
            // lblTelefonoHabitante
            // 
            this.lblTelefonoHabitante.AutoSize = true;
            this.lblTelefonoHabitante.Location = new System.Drawing.Point(32, 213);
            this.lblTelefonoHabitante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefonoHabitante.Name = "lblTelefonoHabitante";
            this.lblTelefonoHabitante.Size = new System.Drawing.Size(82, 16);
            this.lblTelefonoHabitante.TabIndex = 6;
            this.lblTelefonoHabitante.Text = "TELEFONO:";
            // 
            // txtDireccionHabitante
            // 
            this.txtDireccionHabitante.Location = new System.Drawing.Point(140, 140);
            this.txtDireccionHabitante.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccionHabitante.Multiline = true;
            this.txtDireccionHabitante.Name = "txtDireccionHabitante";
            this.txtDireccionHabitante.Size = new System.Drawing.Size(380, 50);
            this.txtDireccionHabitante.TabIndex = 5;
            // 
            // lblDireccionHabitante
            // 
            this.lblDireccionHabitante.AutoSize = true;
            this.lblDireccionHabitante.Location = new System.Drawing.Point(32, 143);
            this.lblDireccionHabitante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDireccionHabitante.Name = "lblDireccionHabitante";
            this.lblDireccionHabitante.Size = new System.Drawing.Size(83, 16);
            this.lblDireccionHabitante.TabIndex = 4;
            this.lblDireccionHabitante.Text = "DIRECCION:";
            // 
            // txtCodigoHabitante
            // 
            this.txtCodigoHabitante.Location = new System.Drawing.Point(140, 85);
            this.txtCodigoHabitante.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoHabitante.Name = "txtCodigoHabitante";
            this.txtCodigoHabitante.Size = new System.Drawing.Size(380, 22);
            this.txtCodigoHabitante.TabIndex = 3;
            // 
            // lblCodigoHabitante
            // 
            this.lblCodigoHabitante.AutoSize = true;
            this.lblCodigoHabitante.Location = new System.Drawing.Point(32, 88);
            this.lblCodigoHabitante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigoHabitante.Name = "lblCodigoHabitante";
            this.lblCodigoHabitante.Size = new System.Drawing.Size(46, 16);
            this.lblCodigoHabitante.TabIndex = 2;
            this.lblCodigoHabitante.Text = "CASA:";
            // 
            // txtNombreHabitante
            // 
            this.txtNombreHabitante.Location = new System.Drawing.Point(140, 35);
            this.txtNombreHabitante.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreHabitante.Name = "txtNombreHabitante";
            this.txtNombreHabitante.Size = new System.Drawing.Size(380, 22);
            this.txtNombreHabitante.TabIndex = 1;
            // 
            // lblNombreHabitante
            // 
            this.lblNombreHabitante.AutoSize = true;
            this.lblNombreHabitante.Location = new System.Drawing.Point(32, 38);
            this.lblNombreHabitante.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreHabitante.Name = "lblNombreHabitante";
            this.lblNombreHabitante.Size = new System.Drawing.Size(69, 16);
            this.lblNombreHabitante.TabIndex = 0;
            this.lblNombreHabitante.Text = "NOMBRE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 28);
            this.label1.TabIndex = 19;
            this.label1.Text = "HABITANTES";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.BackgroundImage = global::ProyectoFinalSistemaDeRegistroMaferrer.Properties.Resources.PATRAS;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(5, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 47);
            this.button1.TabIndex = 21;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.ErrorImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(249, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 51);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox1.Location = new System.Drawing.Point(-6, -9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1466, 72);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "idHabitantes";
            this.id.HeaderText = "idhabitantes";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // casa
            // 
            this.casa.DataPropertyName = "casa";
            this.casa.HeaderText = "Casa";
            this.casa.MinimumWidth = 6;
            this.casa.Name = "casa";
            this.casa.ReadOnly = true;
            // 
            // direccion
            // 
            this.direccion.DataPropertyName = "direccion";
            this.direccion.HeaderText = "Dirección";
            this.direccion.MinimumWidth = 6;
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "telefono";
            this.telefono.HeaderText = "Teléfono";
            this.telefono.MinimumWidth = 6;
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // frmhabitantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 637);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbDatosHabitante);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmhabitantes";
            this.Text = "Habitantes";
            this.Load += new System.EventHandler(this.frmhabitantes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHabitantes)).EndInit();
            this.grbDatosHabitante.ResumeLayout(false);
            this.grbDatosHabitante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdHabitantes;
        private System.Windows.Forms.TextBox txtBuscarHabitantes;
        private System.Windows.Forms.Button btnEliminarHabitante;
        private System.Windows.Forms.Button btnModificarHabitante;
        private System.Windows.Forms.Button btnAgregarHabitante;
        private System.Windows.Forms.TextBox txtTelefonoHabitante;
        private System.Windows.Forms.Label lblTelefonoHabitante;
        private System.Windows.Forms.TextBox txtDireccionHabitante;
        private System.Windows.Forms.Label lblDireccionHabitante;
        private System.Windows.Forms.TextBox txtCodigoHabitante;
        private System.Windows.Forms.Label lblCodigoHabitante;
        private System.Windows.Forms.TextBox txtNombreHabitante;
        private System.Windows.Forms.Label lblNombreHabitante;
        private System.Windows.Forms.GroupBox grbDatosHabitante;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn casa;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
    }
}