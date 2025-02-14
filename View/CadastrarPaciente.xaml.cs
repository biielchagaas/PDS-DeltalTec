
using System;
using DentalTech.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DentalTech.Database;
using MySql.Data.MySqlClient;

namespace DentalTech
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class CadastrarPaciente : Window
    {
        public CadastrarPaciente()
        {
            InitializeComponent();
        }

        private void TextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void AcessoCadastrarFuncionario_Click(object sender, MouseButtonEventArgs a)
        {
            CadastrarFuncionario cadastrarFuncionario = new CadastrarFuncionario();
            cadastrarFuncionario.Show();
            this.Close();
        }

        private void Salvar(object sender, RoutedEventArgs e)
        {
            Inserir();
        }

        void Inserir()
        {
            string nomee = nome.Text;
            string cpff = cpf.Text;
            string statuss = status.Text;
            string estCivil = estadoCiv.Text;
            string rgg = rg.Text;
            string expeditor = expedidor.Text;
            string telefonee = telefone.Text;
            string sexo = genero.Text;
            string emailm = email.Text;
            string cepp = cep.Text;
            string estadoo = estado.Text;
            string cidadee = cidade.Text;
            string bairroo = bairro.Text;
            string enderecoo = rua.Text;
            string numeroo = numero.Text;
            DateTime? dataSelecionada = dataNasc.SelectedDate;

            DateTime datanasc = dataSelecionada.Value;

            string dataFormatada = datanasc.ToString("yyyy/MM/dd");

            try
            {
                Conexao conexao = new Conexao();

                string query = "INSERT INTO Paciente (nome_pac, cpf_pac, status_pac, rg_pac, expedidor_pac, " +
                    "estadoCivil_pac, genero_pac, email_pac, telefone_pac, dataDeNascimento_pac, cep_pac, cidade_pac," +
                    " bairro_pac, rua_pac, numero_pac) VALUES (@Nome_Pac, @Cpf_Pac, @Status_Pac, @Rg_Pac, @Expedidor_Pac, " +
                    "@EstadoCivil_Pac, @Genero_Pac, @Email_Pac, @Telefone_Pac, @DataDeNascimento_Pac, @Cep_Pac, " +
                    "@Cidade_Pac, @Bairro_Pac, @Rua_Pac, @Numero_Pac);";

                using (MySqlCommand command = conexao.Query(query))
                {
                    command.Parameters.AddWithValue("@Nome_Pac", nomee);
                    command.Parameters.AddWithValue("@Cpf_Pac", cpff);
                    command.Parameters.AddWithValue("@Status_Pac", statuss);
                    command.Parameters.AddWithValue("@Rg_Pac", rgg);
                    command.Parameters.AddWithValue("@Expedidor_Pac", expeditor);
                    command.Parameters.AddWithValue("@EstadoCivil_Pac", estCivil);
                    command.Parameters.AddWithValue("@Genero_Pac", sexo);
                    command.Parameters.AddWithValue("@Email_Pac", emailm);
                    command.Parameters.AddWithValue("@Telefone_Pac", telefonee);
                    command.Parameters.AddWithValue("@DataDeNascimento_Pac", dataFormatada);
                    command.Parameters.AddWithValue("@Cep_Pac", cepp);
                    command.Parameters.AddWithValue("@Cidade_Pac", cidadee);
                    command.Parameters.AddWithValue("@Bairro_Pac", bairroo);
                    command.Parameters.AddWithValue("@Rua_Pac", enderecoo);
                    command.Parameters.AddWithValue("@Numero_Pac", numeroo);

                    var result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Paciente cadastrado com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar agendamento.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception)
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
    }
}
