using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Univap.Programacao3.Data;
using Univap.Programacao3.Engine;
using Univap.Projetos1.Model;

namespace Univap.Projetos1
{
    public partial class Frm_Search : FormEngine
    {
        private List<Produto> _produtoList;

        public Frm_Search()
        {
            InitializeComponent();
        }

        private void Frm_Search_Load(object sender, EventArgs e)
        {
            _produtoList = DbContext.GetAll<Produto>();
            if (_produtoList.Count > 0)
            {
                foreach (Produto produto in _produtoList)
                {
                    Cbo_Search_Modelo.Items.Add(produto.ModelosComerciais);
                }
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            string model = Cbo_Search_Modelo.Text;
            var produto = _produtoList.FirstOrDefault(y => y.ModelosComerciais == model);
            Frm_Main.IdProduto = produto.Id;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
