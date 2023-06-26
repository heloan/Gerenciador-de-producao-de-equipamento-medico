using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Univap.Programacao3.Data;
using Univap.Programacao3.Engine;
using Univap.Programacao3.Engine.Engine;
using Univap.Programacao3.Engine.Resources;
using Univap.Projetos1.Model;
using static System.Net.WebRequestMethods;

namespace Univap.Projetos1.View
{
    public partial class Usc_Produto : UserControlEngine
    {
        public static Produto ItemProduto { get; set; }
        private List<NomeAndCodigoTecnico> _tenicoList { get; set; }
        private readonly string _pathImg = FileResources.SolutionPath(@"Assets\img\{0}");
        private readonly string _pathNomeTecnico = FileResources.SolutionPath(@"Assets\File\equipamentos.csv");
        private Bitmap _bitImage;

        public Usc_Produto()
        {
            InitializeComponent();
        }

        private void Usc_Produto_Load(object sender, EventArgs e)
        {
            /// :: Read product list.
            using (StreamReader reader = new StreamReader(_pathNomeTecnico))
            {
                string line;
                _tenicoList = new List<NomeAndCodigoTecnico>();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] itens = line.Split(';');
                    _tenicoList.Add(new NomeAndCodigoTecnico()
                    {
                        NomeTecnico = itens[0],
                        CodigoTecnico = itens[1]
                    });
                }
            }

            /// :: Get form.
            if (Frm_Main.IdProduto != 0)
            {
                ItemProduto = new Produto() { Id = Frm_Main.IdProduto };
                DbContext.Get<Produto>(ItemProduto);
                UpdateFields<Produto>(ItemProduto);

                if(ItemProduto.ImagemProdutoCaminho != null)
                {
                    _bitImage = (Bitmap)Image.FromFile(String.Format(_pathImg, ItemProduto.ImagemProdutoCaminho));
                    Pic_Produto_ImagemProdutoCaminho.Image = _bitImage;
                }
            }
            else
                ItemProduto = new Produto();

            /// :: Apply effect.
            ApplyMaks();
        }

        private void Btn_Produto_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                /// :: Form validation.
                var validation = ValidateFields<Produto>();
                if (validation.Status == ValidateFieldEnum.Result.FieldEmpity)
                    MessageBox.Show("Preencha todos os campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (validation.Status == ValidateFieldEnum.Result.WrongFormat)
                    MessageBox.Show("Formato do nome da propriedade fora do padrão.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    /// :: Add image.
                    if (ItemProduto.ImagemProdutoCaminho != null)
                        validation.Content.ImagemProdutoCaminho = ItemProduto.ImagemProdutoCaminho;
                    if (_bitImage != null)
                    {
                        Guid guid = Guid.NewGuid();
                        string file = guid.ToString() + ".png";
                        _bitImage.Save(String.Format(_pathImg, file), ImageFormat.Png);
                        validation.Content.ImagemProdutoCaminho = file;
                    }

                    /// :: Save info.
                    ItemProduto = validation.Content;
                    ItemProduto.IdFornecedor = 2;
                    ItemProduto.IdResponsavel = 2;
                    ItemProduto.DataCriacao = DateTime.UtcNow;
                    DbContext.Insert<Produto>(ItemProduto);
                    Frm_Main.IdProduto = ItemProduto.Id;
                    MessageBox.Show("Informações salvas com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pic_Produto_ImagemProdutoCaminho_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            if (opFile.ShowDialog() == DialogResult.OK)
            {
                _bitImage = (Bitmap)Image.FromFile(opFile.FileName);
                Pic_Produto_ImagemProdutoCaminho.Image = _bitImage;
            }
            else
                MessageBox.Show("Imagem invalida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Cbo_Produto_NomeTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cbo_Produto_CodigoNomeTecnico.SelectedIndex = Cbo_Produto_NomeTecnico.Items.IndexOf(Cbo_Produto_NomeTecnico.Text);
        }

        private void Cbo_Produto_CodigoNomeTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cbo_Produto_NomeTecnico.SelectedIndex = Cbo_Produto_CodigoNomeTecnico.Items.IndexOf(Cbo_Produto_CodigoNomeTecnico.Text);
        }

        private void Cbo_Produto_NomeTecnico_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Cbo_Produto_NomeTecnico.Text))
            {
                List<NomeAndCodigoTecnico> subList = _tenicoList.FindAll(item => item.NomeTecnico.Contains(Cbo_Produto_NomeTecnico.Text));
        
                if (subList.Count > 1)
                {
                    Cbo_Produto_NomeTecnico.Items.Clear();
                    Cbo_Produto_CodigoNomeTecnico.Items.Clear();

                    foreach (NomeAndCodigoTecnico item in subList)
                    {
                        Cbo_Produto_NomeTecnico.Items.Add(item.NomeTecnico);
                        Cbo_Produto_CodigoNomeTecnico.Items.Add(item.CodigoTecnico);
                    }

                    Cbo_Produto_NomeTecnico.SelectionStart = Cbo_Produto_NomeTecnico.Text.Length;
                }
            }
        }

        private void Cbo_Produto_CodigoNomeTecnico_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Cbo_Produto_CodigoNomeTecnico.Text))
            {
                List<NomeAndCodigoTecnico> subList = _tenicoList.FindAll(
                    item => item.CodigoTecnico.Contains(Cbo_Produto_CodigoNomeTecnico.Text));

                if (subList.Count > 1)
                {
                    Cbo_Produto_NomeTecnico.Items.Clear();
                    Cbo_Produto_CodigoNomeTecnico.Items.Clear();

                    foreach(NomeAndCodigoTecnico item in subList)
                    {
                        Cbo_Produto_NomeTecnico.Items.Add(item.NomeTecnico);
                        Cbo_Produto_CodigoNomeTecnico.Items.Add(item.CodigoTecnico);
                    }
                }
            }
        }
    }
}
