namespace Univap.Projetos1
{
    partial class Frm_Main
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
            this.Mns_Header = new System.Windows.Forms.MenuStrip();
            this.Tsr_Action = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsr_NewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsr_SearchItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tbc_Main = new System.Windows.Forms.TabControl();
            this.Mns_Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mns_Header
            // 
            this.Mns_Header.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsr_Action});
            this.Mns_Header.Location = new System.Drawing.Point(20, 60);
            this.Mns_Header.Name = "Mns_Header";
            this.Mns_Header.Size = new System.Drawing.Size(814, 24);
            this.Mns_Header.TabIndex = 1;
            this.Mns_Header.Text = "menuStrip1";
            // 
            // Tsr_Action
            // 
            this.Tsr_Action.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsr_NewItem,
            this.Tsr_SearchItem});
            this.Tsr_Action.Name = "Tsr_Action";
            this.Tsr_Action.Size = new System.Drawing.Size(51, 20);
            this.Tsr_Action.Text = "Ações";
            // 
            // Tsr_NewItem
            // 
            this.Tsr_NewItem.Name = "Tsr_NewItem";
            this.Tsr_NewItem.Size = new System.Drawing.Size(132, 22);
            this.Tsr_NewItem.Text = "Novo Item";
            this.Tsr_NewItem.Click += new System.EventHandler(this.Tsr_NewItem_Click);
            // 
            // Tsr_SearchItem
            // 
            this.Tsr_SearchItem.Name = "Tsr_SearchItem";
            this.Tsr_SearchItem.Size = new System.Drawing.Size(180, 22);
            this.Tsr_SearchItem.Text = "Busca Item";
            this.Tsr_SearchItem.Click += new System.EventHandler(this.Tsr_SearchItem_Click);
            // 
            // Tbc_Main
            // 
            this.Tbc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tbc_Main.Location = new System.Drawing.Point(20, 84);
            this.Tbc_Main.Name = "Tbc_Main";
            this.Tbc_Main.SelectedIndex = 0;
            this.Tbc_Main.Size = new System.Drawing.Size(814, 562);
            this.Tbc_Main.TabIndex = 2;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(854, 666);
            this.Controls.Add(this.Tbc_Main);
            this.Controls.Add(this.Mns_Header);
            this.MainMenuStrip = this.Mns_Header;
            this.Name = "Frm_Main";
            this.Text = "Gerenciador de equipamentos médico-hospitalares";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.Mns_Header.ResumeLayout(false);
            this.Mns_Header.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Mns_Header;
        private System.Windows.Forms.ToolStripMenuItem Tsr_Action;
        private System.Windows.Forms.ToolStripMenuItem Tsr_NewItem;
        private System.Windows.Forms.TabControl Tbc_Main;
        private System.Windows.Forms.ToolStripMenuItem Tsr_SearchItem;
    }
}