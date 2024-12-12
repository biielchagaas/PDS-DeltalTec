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
using System.Windows.Shapes;
using DentalTech.Database;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace DentalTech.View
{
    /// <summary>
    /// Lógica interna para CadastrarAgendamento.xaml
    /// </summary>
    public partial class CadastrarAgendamento : Window
    {
        public CadastrarAgendamento()
        {
            InitializeComponent();
        }

        private void Salvar(object sender, RoutedEventArgs e)
        {
            Inserir();
        }

        void Inserir()
        {
            string pacientee = paciente.Text;
            string profissional = funcionario.Text;
            DateTime? dataSelecionada = data.SelectedDate;
            DateTime? horaSelecionada = hora.SelectedTime;

            DateTime dataa = dataSelecionada.Value;

            // Formatando a data para o formato brasileiro
            string dataFormatada = dataa.ToString("yyyy/MM/dd");

            

            if (string.IsNullOrWhiteSpace(pacientee) || string.IsNullOrWhiteSpace(profissional))
            {
                MessageBox.Show("Nenhum não pode estar vazio.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                Conexao conexao = new Conexao();
                int idPaciente = -1;
                string query = "SELECT id_pac FROM Paciente WHERE nome_pac = @Nome";

                using (MySqlCommand command = conexao.Query(query))
                {
                    // Adiciona o parâmetro de forma segura
                    command.Parameters.AddWithValue("@Nome", pacientee);

                    // Executa o comando e obtém o resultado
                    object resultado = command.ExecuteScalar();

                    if (resultado != null)
                    {
                        idPaciente = Convert.ToInt32(resultado);
                        Console.WriteLine("ID encontrado: " + idPaciente);
                    }
                    else
                    {
                        Console.WriteLine("Nenhum registro encontrado com esse nome.");
                    }
                }

                int idFuncionario = -1;
                query = "SELECT id_func FROM Funcionario WHERE nome_func = @Nome";

                using (MySqlCommand command = conexao.Query(query))
                {
                    command.Parameters.AddWithValue("@Nome", profissional);

                    object resultado = command.ExecuteScalar();

                    if (resultado != null)
                    {
                        idFuncionario = Convert.ToInt32(resultado);
                        Console.WriteLine("ID encontrado: " + idFuncionario);
                    }
                    else
                    {
                        Console.WriteLine("Nenhum registro encontrado com esse nome.");
                    }
                }

                query = "INSERT INTO agendamento (data_age, hora_age, id_pac_fk, id_func_fk)" +
                    " VALUES (@data, @hora, @idpaciente, @idfuncionario)";

                using(MySqlCommand command = conexao.Query(query))
                {
                    command.Parameters.AddWithValue("@idpaciente", idPaciente);
                    command.Parameters.AddWithValue("@idfuncionario", idFuncionario);
                    command.Parameters.AddWithValue("@data", dataFormatada);
                    command.Parameters.AddWithValue("@hora", horaSelecionada);

                    var result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Agendamento cadastrado com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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
