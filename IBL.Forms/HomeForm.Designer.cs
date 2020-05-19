namespace IBL.Forms
{
    partial class HomeForm
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
            this.btnImportar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblImportar = new System.Windows.Forms.Label();
            this.btnTreinar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAttr1 = new System.Windows.Forms.TextBox();
            this.txtAttr2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblClassificacao = new System.Windows.Forms.Label();
            this.btnFronteiras = new System.Windows.Forms.Button();
            this.lblLeave = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(41, 41);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 0;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblImportar
            // 
            this.lblImportar.AutoSize = true;
            this.lblImportar.Location = new System.Drawing.Point(38, 76);
            this.lblImportar.Name = "lblImportar";
            this.lblImportar.Size = new System.Drawing.Size(0, 13);
            this.lblImportar.TabIndex = 1;
            // 
            // btnTreinar
            // 
            this.btnTreinar.Location = new System.Drawing.Point(238, 41);
            this.btnTreinar.Name = "btnTreinar";
            this.btnTreinar.Size = new System.Drawing.Size(103, 23);
            this.btnTreinar.TabIndex = 2;
            this.btnTreinar.Text = "LeaveOneOut";
            this.btnTreinar.UseVisualStyleBackColor = true;
            this.btnTreinar.Click += new System.EventHandler(this.btnTreinar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Classificar novo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAttr1
            // 
            this.txtAttr1.Location = new System.Drawing.Point(525, 43);
            this.txtAttr1.Name = "txtAttr1";
            this.txtAttr1.Size = new System.Drawing.Size(126, 20);
            this.txtAttr1.TabIndex = 4;
            // 
            // txtAttr2
            // 
            this.txtAttr2.Location = new System.Drawing.Point(525, 75);
            this.txtAttr2.Name = "txtAttr2";
            this.txtAttr2.Size = new System.Drawing.Size(126, 20);
            this.txtAttr2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ATTR 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ATTR 2:";
            // 
            // lblClassificacao
            // 
            this.lblClassificacao.AutoSize = true;
            this.lblClassificacao.Location = new System.Drawing.Point(455, 141);
            this.lblClassificacao.Name = "lblClassificacao";
            this.lblClassificacao.Size = new System.Drawing.Size(0, 13);
            this.lblClassificacao.TabIndex = 8;
            // 
            // btnFronteiras
            // 
            this.btnFronteiras.Location = new System.Drawing.Point(715, 43);
            this.btnFronteiras.Name = "btnFronteiras";
            this.btnFronteiras.Size = new System.Drawing.Size(127, 23);
            this.btnFronteiras.TabIndex = 9;
            this.btnFronteiras.Text = "Ver Fronteiras";
            this.btnFronteiras.UseVisualStyleBackColor = true;
            this.btnFronteiras.Click += new System.EventHandler(this.btnFronteiras_Click);
            // 
            // lblLeave
            // 
            this.lblLeave.AutoSize = true;
            this.lblLeave.Location = new System.Drawing.Point(235, 75);
            this.lblLeave.Name = "lblLeave";
            this.lblLeave.Size = new System.Drawing.Size(0, 13);
            this.lblLeave.TabIndex = 10;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 450);
            this.Controls.Add(this.lblLeave);
            this.Controls.Add(this.btnFronteiras);
            this.Controls.Add(this.lblClassificacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAttr2);
            this.Controls.Add(this.txtAttr1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTreinar);
            this.Controls.Add(this.lblImportar);
            this.Controls.Add(this.btnImportar);
            this.Name = "HomeForm";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblImportar;
        private System.Windows.Forms.Button btnTreinar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAttr1;
        private System.Windows.Forms.TextBox txtAttr2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblClassificacao;
        private System.Windows.Forms.Button btnFronteiras;
        private System.Windows.Forms.Label lblLeave;
    }
}