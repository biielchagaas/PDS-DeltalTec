using DentalTech.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        private void Salvar(object sender, RoutedEventArgs e)
        {
            Inserir();
        }

        void Inserir()
        {
            string nome = produtoo.Text;
            DateTime? dataSelect = fabricacaoo.SelectedDate;
            DateTime? dataSelect2 = vencimentoo.SelectedDate;
            string codigo = codigoo.Text;
            double valor = Convert.ToDouble(valorr.Text);

            DateTime dataFabricacao = dataSelect.Value;
            string dataFormatadaFab = dataFabricacao.ToString("yyyy/MM/dd");

            DateTime dataVencimento = dataSelect2.Value;
            string dataFormatadaVenc = dataVencimento.ToString("yyyy/MM/dd");

            try
            {
                Conexao conexao = new Conexao();

                string query = "insert into Produto (nome_prod, dataFabricacao_prod, dataValidade_prod, codigoBarras_prod, valor_prod)" +
                    " values (@Nome_Prod, @Fabricacao_Prod, @Vencimento_Prod, @Codigo_Prod, @Valor_Prod);";

                using (MySqlCommand command = conexao.Query(query))
                {
                    command.Parameters.AddWithValue("@Nome_Prod", nome);
                    command.Parameters.AddWithValue("@Fabricacao_Prod", dataFormatadaFab);
                    command.Parameters.AddWithValue("@Vencimento_Prod", dataFormatadaVenc);
                    command.Parameters.AddWithValue("@Codigo_Prod", codigo);
                    command.Parameters.AddWithValue("@Valor_Prod", valor);

                    var result = command.ExecuteNonQuery();

                    if(result > 0)
                    {
                        MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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
