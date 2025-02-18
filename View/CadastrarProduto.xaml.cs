using DentalTech.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DentalTech.View
{
    /// <summary>
    /// Lógica interna para CadastrarProduto.xaml
    /// </summary>
    public partial class CadastrarProduto : Window
    {
        public CadastrarProduto()
        {
            InitializeComponent();
        }

        void Inserir()
        {
            string nomee = nome.Text;
            DateTime? dataFabricacao = dataFab.SelectedDate;
            DateTime? dataVencimento = dataVenc.SelectedDate;
            string codigoo = codigo.Text;
            double valorr = Convert.ToDouble(valor.Text);

            DateTime datafab = dataFabricacao.Value;
            DateTime datavenc = dataVencimento.Value;

            string FabricacaoFormatada = datafab.ToString("yyyy/MM/dd");
            string VencimentoFormatado = datavenc.ToString("yyyy/MM/dd");

            try
            {
                Conexao conexao = new Conexao();

                string query = "INSERT INTO PRODUTO (nome_prod, dataFabricacao_prod, dataValidade_prod, codigoBarras_prod, " +
                    "valor_prod) values (@Nome_prod, @Fabricacao_prod, @Vencimento_prod, @CodigoBarras_prod, @Valor_prod);";

                using (MySqlCommand command = conexao.Query(query))
                {

                    command.Parameters.AddWithValue("@Nome_prod", nomee);
                    command.Parameters.AddWithValue("@Fabricacao_prod", FabricacaoFormatada);
                    command.Parameters.AddWithValue("@Vencimento_prod", VencimentoFormatado);
                    command.Parameters.AddWithValue("@CodigoBarras_prod", codigoo);
                    command.Parameters.AddWithValue("@Valor_prod", valorr);

                    var result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar produto.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }


                }
            }
            catch(Exception)
            {

                throw;

            }

        }
        private void MainTreeVie_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // Obtém o item selecionado no TreeView
            var selectedItem = MainTreeView.SelectedItem as TreeViewItem;

            if (selectedItem != null)
            {
                // Verifica o texto do cabeçalho do item selecionado
                if (selectedItem.Header.ToString() == "Cadastrar funcionário")
                {
                    // Abre a nova janela e fecha a atual
                    CadastrarFuncionario cadastroFun = new CadastrarFuncionario();
                    cadastroFun.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Consultar funcionário")
                {
                    // Abre a nova janela e fecha a atual
                    ConsultarFuncionario consultaFun = new ConsultarFuncionario();
                    consultaFun.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Realizar venda")
                {
                    // Abre a nova janela e fecha a atual
                    RealizarVenda realizarVen = new RealizarVenda();
                    realizarVen.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Receber venda")
                {
                    // Abre a nova janela e fecha a atual
                    ReceberVenda recebeVen = new ReceberVenda();
                    recebeVen.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Cadastrar despesa")
                {
                    // Abre a nova janela e fecha a atual
                    CadastrarDespesa cadastrarDes = new CadastrarDespesa();
                    cadastrarDes.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Consultar despesa")
                {
                    // Abre a nova janela e fecha a atual
                    ConsultarDespesa consulDes = new ConsultarDespesa();
                    consulDes.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Cadastrar paciente")
                {
                    // Abre a nova janela e fecha a atual
                    CadastrarPaciente cadastraPac = new CadastrarPaciente();
                    cadastraPac.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Consultar paciente")
                {
                    // Abre a nova janela e fecha a atual
                    ConsultarPaciente consulPac = new ConsultarPaciente();
                    consulPac.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Cadastrar anamnese")
                {
                    // Abre a nova janela e fecha a atual
                    CadastrarAnamnese cadastrarAnamn = new CadastrarAnamnese();
                    cadastrarAnamn.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Consultar anamnese")
                {
                    // Abre a nova janela e fecha a atual
                    ConsultarAnamnese consulAna = new ConsultarAnamnese();
                    consulAna.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Cadastrar consulta")
                {
                    // Abre a nova janela e fecha a atual
                    CadastrarConsulta cadastrarCon = new CadastrarConsulta();
                    cadastrarCon.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Consultar consulta")
                {
                    // Abre a nova janela e fecha a atual
                    ConsultarConsulta consulCon = new ConsultarConsulta();
                    consulCon.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Cadastrar agendamento")
                {
                    // Abre a nova janela e fecha a atual
                    CadastrarAgendamento cadastraAgen = new CadastrarAgendamento();
                    cadastraAgen.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Consultar agendamento")
                {
                    // Abre a nova janela e fecha a atual


                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Cadastrar Produto")
                {
                    // Abre a nova janela e fecha a atual
                    CadastrarProduto cadastrarPro = new CadastrarProduto();
                    cadastrarPro.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Consultar produto")
                {
                    // Abre a nova janela e fecha a atual
                    ConsultarProduto consulCon = new ConsultarProduto();
                    consulCon.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Cadastrar serviço")
                {
                    // Abre a nova janela e fecha a atual
                    CadastrarServico cadastrarSer = new CadastrarServico();
                    cadastrarSer.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Consultar serviço")
                {
                    // Abre a nova janela e fecha a atual
                    ConsultarServico consulSer = new ConsultarServico();
                    consulSer.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Cadastrar orçamento")
                {
                    // Abre a nova janela e fecha a atual
                    CadastrarOrcamento cadastrarOrc = new CadastrarOrcamento();
                    cadastrarOrc.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Consultar orçamento")
                {
                    // Abre a nova janela e fecha a atual
                    ConsultarOrcamento consulOrc = new ConsultarOrcamento();
                    consulOrc.Show();

                    // Fecha a janela atual
                    this.Close();
                }
            }
        }

        private void Salvar(object sender, RoutedEventArgs e)
        {
            Inserir();
        }
    }
}
