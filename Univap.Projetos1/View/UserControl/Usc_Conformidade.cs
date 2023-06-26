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
    public partial class Usc_Conformidade : UserControlEngine
    {
        public static Conformidade ItemConformidade { get; set; }

        public Usc_Conformidade()
        {
            InitializeComponent();
        }

        private void Usc_Conformidade_Load(object sender, EventArgs e)
        {
            /// :: Get form.
            if (Frm_Main.IdProduto != 0)
            {
                ItemConformidade = new Conformidade() { Id = Frm_Main.IdProduto };
                DbContext.Get<Conformidade>(ItemConformidade, "IdProduto", Frm_Main.IdProduto.ToString());
                UpdateFields<Conformidade>(ItemConformidade);
                RendeRangeBar();
            }
            else
            {
                ItemConformidade = new Conformidade();
                Btn_Conformidade_Salvar.Enabled = false;
            }
        }

        private void Btn_Conformidade_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                /// :: Form validation.
                var validation = ValidateFields<Conformidade>();
                if (validation.Status == ValidateFieldEnum.Result.FieldEmpity)
                    MessageBox.Show("Preencha todos os campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (validation.Status == ValidateFieldEnum.Result.WrongFormat)
                    MessageBox.Show("Formato do nome da propriedade fora do padrão.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    /// :: Save info.
                    ItemConformidade = validation.Content;
                    ItemConformidade.IdProduto = Frm_Main.IdProduto;
                    ItemConformidade.DataCriacao = DateTime.UtcNow;
                    DbContext.Insert<Conformidade>(ItemConformidade);
                    RendeRangeBar();
                    MessageBox.Show("Informações salvas com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RendeRangeBar()
        {
            int count = 0;
            int checkedBox = 0;
            foreach (dynamic c in this.Controls)
            {
                if (c is CheckBox)
                {
                    string controlName = c.Name.ToString().Split('_')[2];
                    PropertyInfo pinfo = typeof(Conformidade).GetProperty(controlName);
                    bool result = Convert.ToBoolean(pinfo.GetValue(ItemConformidade, null));
                    if (result) checkedBox++;
                    count++;
                }
            }

            Prg_Conformidade.Minimum = 0;
            Prg_Conformidade.Maximum = count;
            Prg_Conformidade.Value = checkedBox;
        }
    }
}
