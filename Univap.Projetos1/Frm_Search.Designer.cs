namespace Univap.Projetos1
{
    partial class Frm_Search
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
            this.Lbl_Search_ModelosComerciais = new System.Windows.Forms.Label();
            this.Cbo_Search_Modelo = new System.Windows.Forms.ComboBox();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lbl_Search_ModelosComerciais
            // 
            this.Lbl_Search_ModelosComerciais.AutoSize = true;
            this.Lbl_Search_ModelosComerciais.Location = new System.Drawing.Point(20, 61);
            this.Lbl_Search_ModelosComerciais.Name = "Lbl_Search_ModelosComerciais";
            this.Lbl_Search_ModelosComerciais.Size = new System.Drawing.Size(343, 13);
            this.Lbl_Search_ModelosComerciais.TabIndex = 1;
            this.Lbl_Search_ModelosComerciais.Text = "Modelos Comerciais (incluindo códigos de identificação – Part Number):";
            // 
            // Cbo_Search_Modelo
            // 
            this.Cbo_Search_Modelo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cbo_Search_Modelo.FormattingEnabled = true;
            this.Cbo_Search_Modelo.Location = new System.Drawing.Point(23, 78);
            this.Cbo_Search_Modelo.Name = "Cbo_Search_Modelo";
            this.Cbo_Search_Modelo.Size = new System.Drawing.Size(340, 21);
            this.Cbo_Search_Modelo.TabIndex = 2;
            // 
            // Btn_Search
            // 
            this.Btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Search.Location = new System.Drawing.Point(248, 105);
            this.Btn_Search.MinimumSize = new System.Drawing.Size(0, 36);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(115, 36);
            this.Btn_Search.TabIndex = 31;
            this.Btn_Search.Text = "Buscar";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // Frm_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 162);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.Cbo_Search_Modelo);
            this.Controls.Add(this.Lbl_Search_ModelosComerciais);
            this.Name = "Frm_Search";
            this.Text = "Busca Item";
            this.Load += new System.EventHandler(this.Frm_Search_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lbl_Search_ModelosComerciais;
        private System.Windows.Forms.ComboBox Cbo_Search_Modelo;
        private System.Windows.Forms.Button Btn_Search;
    }
}