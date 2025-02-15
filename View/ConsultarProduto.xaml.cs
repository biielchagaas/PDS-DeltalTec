using DentalTech.Database;
using DentalTech.Models;
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
    /// Lógica interna para ConsultarProduto.xaml
    /// </summary>
    public partial class ConsultarProduto : Window
    {
        public ConsultarProduto()
        {
            InitializeComponent();
        }
        public void Delete(ConsultarProdut t)
        {
            Conexao conn = null; // Declara a conexão antes do try

            try
            {
                conn = new Conexao(); // Inicializa a conexão corretamente
                MySqlCommand query = conn.Query("DELETE FROM produto WHERE id_prod = @id"); // Usa corretamente o método Query()

                query.Parameters.AddWithValue("@id", t.Id); // Usa t.Id corretamente

                int result = query.ExecuteNonQuery(); // Executa a query

                if (result == 0)
                    throw new Exception("Registro de produto não removido da base de dados. Verifique e tente novamente.");
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao deletar o produto " + e.Message);
            }
            finally
            {
                if (conn != null) // Garante que a conexão foi iniciada antes de fechar
                {
                    conn.Close();
                }
            }
        }
        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            var produtoSelected = dataGrid.SelectedItem as ConsultarProdut;

            var result = MessageBox.Show($"Deseja realmente remover o produto  '{produtoSelected.Id}'?",
                "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ConsultarProduto();
                    dao.Delete(produtoSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadDataGrid()
        {
            throw new NotImplementedException();
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
    }
}
