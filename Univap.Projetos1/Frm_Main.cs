using System;
using System.Windows.Forms;
using Univap.Programacao3.Engine;
using Univap.Projetos1.View;

namespace Univap.Projetos1
{
    public partial class Frm_Main : FormEngine
    {
        public static int IdProduto { get; set; }
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void GenerateTabs()
        {
            CloseAllTabs(Tbc_Main);

            var uscProduto = new Usc_Produto();
            uscProduto.Dock = DockStyle.Fill;

            TabPage tbProduto = new TabPage();
            tbProduto.Name = "Tab_Produto";
            tbProduto.Text = "Produto";
            Tbc_Main.TabPages.Add(tbProduto);
            tbProduto.Controls.Add(uscProduto);

            var uscConformidade = new Usc_Conformidade();
            uscConformidade.Dock = DockStyle.Fill;
            TabPage tbConformidade = new TabPage();
            tbConformidade.Name = "Tab_Conformidade";
            tbConformidade.Text = "Conformidade";
            Tbc_Main.TabPages.Add(tbConformidade);
            tbConformidade.Controls.Add(uscConformidade);

            var uscVenda = new Usc_Venda();
            uscVenda.Dock = DockStyle.Fill;
            TabPage tbVenda = new TabPage();
            tbVenda.Name = "Tab_Venda";
            tbVenda.Text = "Localização";
            Tbc_Main.TabPages.Add(tbVenda);
            tbVenda.Controls.Add(uscVenda);
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
        }

        private void Tsr_NewItem_Click(object sender, EventArgs e)
        {            
            IdProduto = 0;
            GenerateTabs();
        }

        private void Tsr_SearchItem_Click(object sender, EventArgs e)
        {
            var formSearch = new Frm_Search();
            DialogResult result = formSearch.ShowDialog();
            if (result == DialogResult.OK)
            {
                GenerateTabs();
            }
        }
    }
}
