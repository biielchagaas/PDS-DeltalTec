
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
            DateTime? dataSelecionada = dataNasc.SelectedDate;
            string cepp = cep.Text;
            string estadoo = estado.Text;
            string cidadee = cidade.Text;
            string bairroo = bairro.Text;
            string enderecoo = rua.Text;
            string numeroo = numero.Text;

            DateTime datanasc = dataSelecionada.Value;

            // Formatando a data para o formato brasileiro
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
                        Close();
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
    }
}
