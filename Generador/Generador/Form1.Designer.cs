namespace Generador
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
            this.txtValueA = new System.Windows.Forms.TextBox();
            this.txtValueC = new System.Windows.Forms.TextBox();
            this.txtValueX = new System.Windows.Forms.TextBox();
            this.txtValueM = new System.Windows.Forms.TextBox();
            this.bntGenerete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtValueA
            // 
            this.txtValueA.Location = new System.Drawing.Point(51, 77);
            this.txtValueA.Name = "txtValueA";
            this.txtValueA.Size = new System.Drawing.Size(100, 20);
            this.txtValueA.TabIndex = 0;
            // 
            // txtValueC
            // 
            this.txtValueC.Location = new System.Drawing.Point(183, 77);
            this.txtValueC.Name = "txtValueC";
            this.txtValueC.Size = new System.Drawing.Size(100, 20);
            this.txtValueC.TabIndex = 1;
            // 
            // txtValueX
            // 
            this.txtValueX.Location = new System.Drawing.Point(314, 77);
            this.txtValueX.Name = "txtValueX";
            this.txtValueX.Size = new System.Drawing.Size(100, 20);
            this.txtValueX.TabIndex = 2;
            // 
            // txtValueM
            // 
            this.txtValueM.Location = new System.Drawing.Point(461, 77);
            this.txtValueM.Name = "txtValueM";
            this.txtValueM.Size = new System.Drawing.Size(95, 20);
            this.txtValueM.TabIndex = 3;
            // 
            // bntGenerete
            // 
            this.bntGenerete.Location = new System.Drawing.Point(348, 145);
            this.bntGenerete.Name = "bntGenerete";
            this.bntGenerete.Size = new System.Drawing.Size(101, 30);
            this.bntGenerete.TabIndex = 4;
            this.bntGenerete.Text = "button1";
            this.bntGenerete.UseVisualStyleBackColor = true;
            this.bntGenerete.Click += new System.EventHandler(this.bntGenerete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(490, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(153, 172);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(100, 20);
            this.txtMax.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "label5";
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(348, 181);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(101, 30);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "button1";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(348, 217);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(101, 30);
            this.btnView.TabIndex = 12;
            this.btnView.Text = "button1";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 261);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bntGenerete);
            this.Controls.Add(this.txtValueM);
            this.Controls.Add(this.txtValueX);
            this.Controls.Add(this.txtValueC);
            this.Controls.Add(this.txtValueA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValueA;
        private System.Windows.Forms.TextBox txtValueC;
        private System.Windows.Forms.TextBox txtValueX;
        private System.Windows.Forms.TextBox txtValueM;
        private System.Windows.Forms.Button bntGenerete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnView;
    }
}

