﻿namespace Almacen
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cagarNúmerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarNúmerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(791, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cagarNúmerosToolStripMenuItem,
            this.mostrarNúmerosToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(155, 20);
            this.archivoToolStripMenuItem.Text = "&Números pseudoaletorios";
            // 
            // cagarNúmerosToolStripMenuItem
            // 
            this.cagarNúmerosToolStripMenuItem.Name = "cagarNúmerosToolStripMenuItem";
            this.cagarNúmerosToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.cagarNúmerosToolStripMenuItem.Text = "Cagar números";
            this.cagarNúmerosToolStripMenuItem.Click += new System.EventHandler(this.cagarNúmerosToolStripMenuItem_Click);
            // 
            // mostrarNúmerosToolStripMenuItem
            // 
            this.mostrarNúmerosToolStripMenuItem.Name = "mostrarNúmerosToolStripMenuItem";
            this.mostrarNúmerosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.mostrarNúmerosToolStripMenuItem.Text = "Mostrar Números";
            this.mostrarNúmerosToolStripMenuItem.Click += new System.EventHandler(this.mostrarNúmerosToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 529);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cagarNúmerosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarNúmerosToolStripMenuItem;

    }
}

