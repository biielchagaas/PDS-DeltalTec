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
    /// Lógica interna para RelatorioOrcamento.xaml
    /// </summary>
    public partial class RelatorioOrcamento : Window
    {
        public RelatorioOrcamento()
        {
            InitializeComponent();
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void MainTreeView6_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // Obtém o item selecionado no TreeView
            var selectedItem = MainTreeView6.SelectedItem as TreeViewItem;
            if (selectedItem != null)
            {
                if (selectedItem.Header.ToString() == "Emitir relatório de consulta")
                {
                    // Abre a nova janela e fecha a atual
                    RelatorioConsulta relatorioConsulta = new RelatorioConsulta();
                    relatorioConsulta.Show();
                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Emitir relatório")
                {
                    RelatorioFuncionario relatorioFuncionario = new RelatorioFuncionario();
                    relatorioFuncionario.Show();
                    // Fecha a janela atual
                    this.Close();
                }
                if (selectedItem.Header.ToString() == "Emitir relatório de paciente")
                {
                    RelatorioPaciente relatorioPaciente = new RelatorioPaciente();
                    relatorioPaciente.Show();
                    // Fecha a janela atual
                    this.Close();
                }
                else if (selectedItem.Header.ToString() == "Emitir relatório de venda")
                {
                    RelatorioVenda relatorioVenda = new RelatorioVenda();
                    relatorioVenda.Show();
                    // Fecha a janela atual
                    this.Close();
                }
                else if (selectedItem.Header.ToString() == "Emitir relatório de despesa")
                {
                    // Abre a nova janela e fecha a atual
                    RelatorioDespesa relatorioDespesa = new RelatorioDespesa();
                    relatorioDespesa.Show();
                    // Fecha a janela atual
                    this.Close();
                }
                else if (selectedItem.Header.ToString() == "Emitir relatório do caixa")
                {
                    /*ADENDO*/
                   /* RelatorioCaixa relatorioCaixa = new RelatorioCaixa();
                    relatorioCaixa.Show();*/
                    // Fecha a janela atual
                    this.Close();
                }
                else if (selectedItem.Header.ToString() == "Emitir relatório de produto")
                {
                    /*ADENDO*/
                    /*RelatorioProduto relatorioProduto = new RelatorioProduto();
                    relatorioProduto.Show();*/
                    // Fecha a janela atual
                    this.Close();
                }
            }
        }
    }
}