using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    partial class MENUPRINCIPAL
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MENUPRINCIPAL));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mENUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNICIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hABITANTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPORTACIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vISITANTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNCIDENTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEPORTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(213, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "REGISTROS DE LA COLONIA MASFERRER";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mENUToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mENUToolStripMenuItem
            // 
            this.mENUToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iNICIOToolStripMenuItem,
            this.hABITANTESToolStripMenuItem,
            this.aPORTACIONESToolStripMenuItem,
            this.vISITANTESToolStripMenuItem,
            this.iNCIDENTESToolStripMenuItem,
            this.rEPORTESToolStripMenuItem});
            this.mENUToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mENUToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.mENUToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mENUToolStripMenuItem.Image")));
            this.mENUToolStripMenuItem.Name = "mENUToolStripMenuItem";
            this.mENUToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.mENUToolStripMenuItem.Text = "MENU";
            // 
            // iNICIOToolStripMenuItem
            // 
            this.iNICIOToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("iNICIOToolStripMenuItem.Image")));
            this.iNICIOToolStripMenuItem.Name = "iNICIOToolStripMenuItem";
            this.iNICIOToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.iNICIOToolStripMenuItem.Text = "INICIO";
            this.iNICIOToolStripMenuItem.Click += new System.EventHandler(this.iNICIOToolStripMenuItem_Click);
            // 
            // hABITANTESToolStripMenuItem
            // 
            this.hABITANTESToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hABITANTESToolStripMenuItem.BackgroundImage")));
            this.hABITANTESToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.hABITANTESToolStripMenuItem.Checked = true;
            this.hABITANTESToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hABITANTESToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hABITANTESToolStripMenuItem.Image")));
            this.hABITANTESToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hABITANTESToolStripMenuItem.Name = "hABITANTESToolStripMenuItem";
            this.hABITANTESToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.hABITANTESToolStripMenuItem.Text = "HABITANTES";
            this.hABITANTESToolStripMenuItem.Click += new System.EventHandler(this.hABITANTESToolStripMenuItem_Click);
            // 
            // aPORTACIONESToolStripMenuItem
            // 
            this.aPORTACIONESToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aPORTACIONESToolStripMenuItem.Image")));
            this.aPORTACIONESToolStripMenuItem.Name = "aPORTACIONESToolStripMenuItem";
            this.aPORTACIONESToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.aPORTACIONESToolStripMenuItem.Text = "APORTACIONES";
            this.aPORTACIONESToolStripMenuItem.Click += new System.EventHandler(this.aPORTACIONESToolStripMenuItem_Click);
            // 
            // vISITANTESToolStripMenuItem
            // 
            this.vISITANTESToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("vISITANTESToolStripMenuItem.Image")));
            this.vISITANTESToolStripMenuItem.Name = "vISITANTESToolStripMenuItem";
            this.vISITANTESToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.vISITANTESToolStripMenuItem.Text = "VISITANTES";
            this.vISITANTESToolStripMenuItem.Click += new System.EventHandler(this.vISITANTESToolStripMenuItem_Click);
            // 
            // iNCIDENTESToolStripMenuItem
            // 
            this.iNCIDENTESToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("iNCIDENTESToolStripMenuItem.Image")));
            this.iNCIDENTESToolStripMenuItem.Name = "iNCIDENTESToolStripMenuItem";
            this.iNCIDENTESToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.iNCIDENTESToolStripMenuItem.Text = "INCIDENTES";
            this.iNCIDENTESToolStripMenuItem.Click += new System.EventHandler(this.iNCIDENTESToolStripMenuItem_Click);
            // 
            // rEPORTESToolStripMenuItem
            // 
            this.rEPORTESToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rEPORTESToolStripMenuItem.Image")));
            this.rEPORTESToolStripMenuItem.Name = "rEPORTESToolStripMenuItem";
            this.rEPORTESToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.rEPORTESToolStripMenuItem.Text = "REPORTES";
            this.rEPORTESToolStripMenuItem.Click += new System.EventHandler(this.rEPORTESToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(159, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(656, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "BIENVENIDO AL SISTEMA DE REGISTRO DE LA COLONIA MASFERRER";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 6;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(638, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "CERRAR SISTEMA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::ProyectoFinalSistemaDeRegistroMaferrer.Properties.Resources.salir;
            this.pictureBox3.Location = new System.Drawing.Point(576, 342);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(318, 57);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(308, 219);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox1.Location = new System.Drawing.Point(-5, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 454);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MENUPRINCIPAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 400);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MENUPRINCIPAL";
            this.Text = "MENUPRINCIPAL";
            this.Load += new System.EventHandler(this.MENUPRINCIPAL_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mENUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNICIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPORTACIONESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hABITANTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vISITANTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNCIDENTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEPORTESToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private Button button1;
        private PictureBox pictureBox3;
    }
}