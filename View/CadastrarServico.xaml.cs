using DentalTech.Database;
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
//using DentalTech.Database;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Markup;

namespace DentalTech.View
{
    /// <summary>
    /// Lógica interna para CadastrarServico.xaml
    /// </summary>
    public partial class CadastrarServico : Window
    {
        public CadastrarServico()
        {
            InitializeComponent();
            PreencherComboBox();
        }
        void PreencherComboBox()
        {
            try
            {
                Conexao conexao = new Conexao();
                string query = "SELECT nome_func FROM Funcionario";

                using (MySqlCommand command = conexao.Query(query))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Adiciona cada registro ao ComboBox
                            profissionais.Items.Add(reader["nome_func"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
            }
        }

        private void Salvar(object sender, RoutedEventArgs e)
        {
            Inserir();
        }

        void Inserir()
        {
            string servicoo = servico.Text;
            string desc = descricao.Text;

            try
            {
                Conexao conexao = new Conexao();

                int profissional = -1;
                string query = "SELECT id_func FROM Funcionario WHERE nome_func = @Nome";

                using (MySqlCommand command = conexao.Query(query))
                {
                    command.Parameters.AddWithValue("@Nome", profissional);

                    object resultado = command.ExecuteScalar();

                    if (resultado != null)
                    {
                        profissional = Convert.ToInt32(resultado);
                        Console.WriteLine("ID encontrado: " + profissional);
                    }
                    else
                    {
                        Console.WriteLine("Nenhum registro encontrado com esse nome.");
                    }
                }

                query = "INSERT INTO Servico (nome_serv, descricao_serv, id_func_fk) VALUES (@servico, @descricao, @profissional);";

                using (MySqlCommand command = conexao.Query(query))
                {
                    command.Parameters.AddWithValue("@servico", servicoo);
                    command.Parameters.AddWithValue("@descricao", desc);
                    command.Parameters.AddWithValue("@profissional", profissional);
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Serviço cadastrado com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar serviço.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
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
    }
}
