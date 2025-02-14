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
using DentalTech.Database;
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
    }
}
