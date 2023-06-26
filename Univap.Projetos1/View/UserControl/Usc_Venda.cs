using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Univap.Programacao3.Data;
using Univap.Programacao3.Engine;
using Univap.Programacao3.Engine.Engine;
using Univap.Projetos1.Model;

namespace Univap.Projetos1.View
{
    public partial class Usc_Venda : UserControlEngine
    {
        public static Venda ItemVenda { get; set; }

        public Usc_Venda()
        {
            InitializeComponent();
        }

        private void Usc_Venda_Load(object sender, EventArgs e)
        {
            /// :: Get form.
            if (Frm_Main.IdProduto != 0)
            {
                ItemVenda = new Venda() { Id = Frm_Main.IdProduto };
                DbContext.Get<Venda>(ItemVenda, "IdProduto", Frm_Main.IdProduto.ToString());
                UpdateFields<Venda>(ItemVenda);
            }
            else
            {
                ItemVenda = new Venda();
                Btn_Venda_Salvar.Enabled = false;
            }

            /// :: Apply effect.
            ApplyMaks();
        }

        private void Btn_Venda_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                /// :: Form validation.
                var validation = ValidateFields<Venda>();
                if (validation.Status == ValidateFieldEnum.Result.FieldEmpity)
                    MessageBox.Show("Preencha todos os campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (validation.Status == ValidateFieldEnum.Result.WrongFormat)
                    MessageBox.Show("Formato do nome da propriedade fora do padrão.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    /// :: Save info.
                    ItemVenda = validation.Content;
                    ItemVenda.IdProduto = Frm_Main.IdProduto;
                    ItemVenda.DataVenda = DateTime.UtcNow;
                    ItemVenda.DataCriacao = DateTime.UtcNow;
                    DbContext.Insert<Venda>(ItemVenda);
                    MessageBox.Show("Informações salvas com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
