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
using DentalTech.Database;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Markup;

namespace DentalTech.View
{
    /// <summary>
    /// Lógica interna para CadastrarAnamnese.xaml
    /// </summary>
    public partial class CadastrarAnamnese : Window
    {
        public CadastrarAnamnese()
        {
            InitializeComponent();
            PreencherComboBox();
        }
        private void Salvar(object sender, RoutedEventArgs e)
        {
            Inserir();
        }

        void Inserir ()
        {
            string pacientee = Pacientes.Text;
            string profissional = Funcionarios.Text;
            bool[] valueBool = new bool[8];
            int[] valueIndex = new int[8];
            DateTime? dataSelecionada = Data.SelectedDate;
            DateTime dataa = dataSelecionada.Value;

            string dataFormatada = dataa.ToString("yyyy/MM/dd");

            valueIndex[0] = febre.SelectedIndex;
            valueIndex[1] = tratamento.SelectedIndex;
            valueIndex[2] = cicatrizacao.SelectedIndex;
            valueIndex[3] = anestesia.SelectedIndex;
            valueIndex[4] = drogas.SelectedIndex;
            valueIndex[5] = diabetes.SelectedIndex;
            valueIndex[6] = doencas.SelectedIndex;
            valueIndex[7] = hipertensao.SelectedIndex;

            for (int i = 0; i < 8; i++)
            {
                if (valueIndex[i] == 0)
                {
                    valueBool[i] = true;
                }
                else
                {
                    valueBool[i] = false;
                }
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

                query = "INSERT INTO anamnese (data_anam, febre_anam, tratamento_anam, cicatrizacao_anam, anestesia_anam, " +
                    "drogas_anam, diabetes_anam, doencas_anam, hipertensao_anam, id_pac_fk, id_func_fk) VALUES (@data, @febre, @tratamento, " +
                    "@cicatrizacao, @anestesia, @drogas, @diabetes, @doencas, @hipertensao, @idpaciente, @idfuncionario)";

                using(MySqlCommand command = conexao.Query(query))
                {
                    command.Parameters.AddWithValue("@data", dataFormatada);
                    command.Parameters.AddWithValue("@febre", valueBool[0]);
                    command.Parameters.AddWithValue("@tratamento", valueBool[1]);
                    command.Parameters.AddWithValue("@cicatrizacao", valueBool[2]);
                    command.Parameters.AddWithValue("@anestesia", valueBool[3]);
                    command.Parameters.AddWithValue("@drogas", valueBool[4]);
                    command.Parameters.AddWithValue("@diabetes", valueBool[5]);
                    command.Parameters.AddWithValue("@doencas", valueBool[6]);
                    command.Parameters.AddWithValue("@hipertensao", valueBool[7]);
                    command.Parameters.AddWithValue("@idpaciente", idPaciente);
                    command.Parameters.AddWithValue("@idfuncionario", idFuncionario);

                    var result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Anamnese cadastrada com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar anamnese.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
            }
        }
        void PreencherComboBox()
        {
            try
            {
                Conexao conexao = new Conexao();
                string query = "SELECT nome_pac FROM Paciente";

                using (MySqlCommand command = conexao.Query(query))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Adiciona cada registro ao ComboBox
                            Pacientes.Items.Add(reader["nome_pac"].ToString());
                        }
                    }
                }

                query = "SELECT nome_func FROM Funcionario";

                using (MySqlCommand command = conexao.Query(query))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Adiciona cada registro ao ComboBox
                            Funcionarios.Items.Add(reader["nome_func"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
            }
        }
    }
}
