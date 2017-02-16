namespace ReaderDataBase
{
    partial class Form1
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
            this.btnUpdateCatalog = new System.Windows.Forms.Button();
            this.btnUpdateOrden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpdateCatalog
            // 
            this.btnUpdateCatalog.Location = new System.Drawing.Point(52, 152);
            this.btnUpdateCatalog.Name = "btnUpdateCatalog";
            this.btnUpdateCatalog.Size = new System.Drawing.Size(82, 36);
            this.btnUpdateCatalog.TabIndex = 0;
            this.btnUpdateCatalog.Text = "Actualizar Catalogo";
            this.btnUpdateCatalog.UseVisualStyleBackColor = true;
            this.btnUpdateCatalog.Click += new System.EventHandler(this.btnUpdateCatalog_Click);
            // 
            // btnUpdateOrden
            // 
            this.btnUpdateOrden.Location = new System.Drawing.Point(191, 152);
            this.btnUpdateOrden.Name = "btnUpdateOrden";
            this.btnUpdateOrden.Size = new System.Drawing.Size(125, 36);
            this.btnUpdateOrden.TabIndex = 1;
            this.btnUpdateOrden.Text = "Actualizar ordenes de trabajo";
            this.btnUpdateOrden.UseVisualStyleBackColor = true;
            this.btnUpdateOrden.Click += new System.EventHandler(this.btnUpdateOrden_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 250);
            this.Controls.Add(this.btnUpdateOrden);
            this.Controls.Add(this.btnUpdateCatalog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateCatalog;
        private System.Windows.Forms.Button btnUpdateOrden;
    }
}

