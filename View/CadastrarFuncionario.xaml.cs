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
using MySql.Data.MySqlClient;

namespace DentalTech.View
{
    /// <summary>
    /// Lógica interna para CadastrarFuncionario.xaml
    /// </summary>
    public partial class CadastrarFuncionario : Window
    {
        public CadastrarFuncionario()
        {
            InitializeComponent();
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
            string estadocivil = estCivil.Text;
            string rgg = rg.Text;
            string expedidorr = expedidor.Text;
            string telefonee = telefone.Text;
            string generoo = genero.Text;
            string emaill = email.Text;
            DateTime? datanc = dataNasc.SelectedDate;
            string cepp = cep.Text;
            string est = estado.Text; 
            string cid = cidade.Text;
            string ruaa = rua.Text;
            string bairroo = bairro.Text;
            string numeroo = numero.Text;
            DateTime? dataamiss = dataadmissao.SelectedDate;
            string ctpss = ctps.Text;
            string cargoo = cargo.Text;
            string senhaa = senha.Password;
            string conffsenha = confsenha.Password;

            DateTime datanasc = datanc.Value;
            string dataFormatada = datanasc.ToString("yyyy/MM/dd");

            DateTime data = dataamiss.Value;
            string dataAdmis = data.ToString("yyyy/MM/dd");


            try
            {

                Conexao conexao = new Conexao();

                string query = "INSERT INTO Funcionario (nome_func, cpf_func, status_func, rg_func, expedidor_func, estadoCivil_func, " +
                    " genero_func, cargo_func, email_func, telefone_func, dataDeNascimento_func, cep_func, cidade_func, bairro_func, " +
                    "rua_func, numero_func, dataDeAdmissao_func, ctps_func, senha_func) VALUES (@Nome_Func, @Cpf_Func, @Status_Func, @Rg_Func," +
                    "@Expedidor_Func, @EstadoCivil_Func, @Genero_Func, @Cargo_Func, @Email_Func, @Telefone_Func, @DataNascimento_Func, @Cep_Func, " +
                    "@Cidade_Func, @Bairro_Func, @Rua_Func, @Numero_Func, @DataAdmissao_Func, @Ctps_Func, @Senha_Func);";



                using (MySqlCommand command = conexao.Query(query))
                {
                    command.Parameters.AddWithValue("@Nome_Func", nomee);
                    command.Parameters.AddWithValue("@Cpf_Func", cpff);
                    command.Parameters.AddWithValue("@Status_Func", statuss);
                    command.Parameters.AddWithValue("@Rg_Func", rgg);
                    command.Parameters.AddWithValue("@Expedidor_Func", expedidorr);
                    command.Parameters.AddWithValue("@EstadoCivil_Func", estadocivil);
                    command.Parameters.AddWithValue("@Genero_Func", generoo);
                    command.Parameters.AddWithValue("@Cargo_Func", cargoo);
                    command.Parameters.AddWithValue("@Email_Func", emaill);
                    command.Parameters.AddWithValue("@Telefone_Func", telefonee);
                    command.Parameters.AddWithValue("@DataNascimento_Func", dataFormatada);
                    command.Parameters.AddWithValue("@Cep_Func", cepp);
                    command.Parameters.AddWithValue("@Cidade_Func", cid);
                    command.Parameters.AddWithValue("@Bairro_Func", bairroo);
                    command.Parameters.AddWithValue("@Rua_Func", ruaa);
                    command.Parameters.AddWithValue("@Numero_Func", numeroo);
                    command.Parameters.AddWithValue("@DataAdmissao_Func", dataAdmis);
                    command.Parameters.AddWithValue("@Ctps_Func", ctpss);
                    command.Parameters.AddWithValue("@Senha_Func", senhaa);

                    var result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Funcionário cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ctps_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cep_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
