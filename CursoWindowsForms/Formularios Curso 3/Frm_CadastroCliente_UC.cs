using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoWindowsFormsBiblioteca.Classes;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using System.Windows.Forms;


namespace CursoWindowsForms
{
    public partial class Frm_CadastroCliente_UC : UserControl
    {
        public Frm_CadastroCliente_UC()
        {
            InitializeComponent();
            Grp_Codigo.Text = "Código";
            Grp_DadosPessoais.Text = "Dados Pessoais";
            Grp_Endereco.Text = "Endereço";
            Grp_Genero.Text = "Gênero";
            Grp_Outros.Text = "Outras Informações";
            Lbl_Bairro.Text = "Bairro";
            Lbl_CEP.Text = "CEP";
            Lbl_Complemento.Text = "Complemento";
            Lbl_CPF.Text = "CPF";
            Lbl_Estado.Text = "Estado";
            Lbl_Logradouro.Text = "Logradouro";
            Lbl_NomeCliente.Text = "Nome do Cliente";
            Lbl_NomeMae.Text = "Nome da Mãe";
            Lbl_NomePai.Text = "Nome do Pai";
            Lbl_Profissao.Text = "Profissão";
            Lbl_Cidade.Text = "Cidade";
            Lbl_RendaFamiliar.Text = "Renda Familiar";
            Lbl_Telefone.Text = "Telefone";
            Chk_TemPai.Text = "Pai desconhecido";
            Rdb_Feminino.Text = "Feminino";
            Rdb_Masculino.Text = "Masculino";
            Rdb_Indefinido.Text = "Prefiro não informar";
            Tls_Principal.Items[0].ToolTipText = "Incluir um novo cliente na base de dados"; 
            Tls_Principal.Items[1].ToolTipText = "Capturar um cliente já cadastrado na base";
            Tls_Principal.Items[2].ToolTipText = "Atualizar um cliente já cadastrado";
            Tls_Principal.Items[3].ToolTipText = "Apagar um cliente selecionado";
            Tls_Principal.Items[4].ToolTipText = "Limpar dados da tela de entrada de dados";
            Cmb_Estado.Items.Add("AC - ACRE");
            Cmb_Estado.Items.Add("AL - ALAGOAS");
            Cmb_Estado.Items.Add("AP - AMAPA");
            Cmb_Estado.Items.Add("AM - AMAZONAS");
            Cmb_Estado.Items.Add("SP - SÃO PAULO");
            Cmb_Estado.Items.Add("RS - RIO GRANDE DO SUL");
            Cmb_Estado.Items.Add("MG - MINAS GERAIS");
        }

        private void Chk_TemPai_CheckedChanged(object sender, EventArgs e)
        {
            if(Chk_TemPai.Checked)
            {
                Txt_NomePai.Enabled = false;
            }
            else
            {
                Txt_NomePai.Enabled = true;
            }
        }

        private void novoToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.Unit C = new Cliente.Unit();
                C = LeituraFormulario();
                C.ValidaClasse();
                C.ValidaComplemento();
                MessageBox.Show("Classe foi inicializada sem erros", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(ValidationException Ex)
            {
                MessageBox.Show(Ex.Message,"ByteBank",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Cliente.Unit LeituraFormulario()
        {
            Cliente.Unit C = new Cliente.Unit();
            C.Id = Txt_Codigo.Text;
            C.Nome = Txt_NomeCliente.Text;
            C.NomeMae = Txt_NomeMae.Text;
            C.NomePai = Txt_NomePai.Text;
            if(Chk_TemPai.Checked)
            {
                C.NaoTemPai = true;
            }
            else
            {
                C.NaoTemPai = false;
            }
            if(Rdb_Masculino.Checked)
            {
                C.Genero = 0;
            }
            if (Rdb_Feminino.Checked)
            {
                C.Genero = 1;
            }
            if (Rdb_Indefinido.Checked)
            {
                C.Genero = 2;
            }
            C.Cpf = Txt_CPF.Text;
            C.Cep = Txt_CEP.Text;
            C.Logradouro = Txt_Logradouro.Text;
            C.Complemento = Txt_Complemento.Text;
            C.Cidade = Txt_Cidade.Text;
            C.Bairro = Txt_Bairro.Text;
            if(Cmb_Estado.SelectedIndex < 0)
            {
                C.Estado = "";
            }
            else
            {
                C.Estado = Cmb_Estado.Items[Cmb_Estado.SelectedIndex].ToString();
            }
            C.Telefone = Txt_Telefone.Text;
            C.Profissao = Txt_Profissao.Text;
            
            if(Information.IsNumeric(Txt_RendaFamiliar.Text))
            {
                Double vRenda = Convert.ToDouble(Txt_RendaFamiliar.Text);
                if(vRenda < 0)
                {
                    C.RendaFamiliar = 0;
                }
                else
                {
                    C.RendaFamiliar = vRenda;
                }
            }
            

            return C;
        }
    }
}
