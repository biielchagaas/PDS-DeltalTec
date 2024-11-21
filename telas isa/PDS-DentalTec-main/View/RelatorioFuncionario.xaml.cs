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
    /// Lógica interna para RelatorioFuncionario.xaml
    /// </summary>
    public partial class RelatorioFuncionario : Window
    {
        public RelatorioFuncionario()
        {
            InitializeComponent();
        }

        private void MainTreeVie_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // Obtém o item selecionado no TreeView
            var selectedItem = MainTreeView.SelectedItem as TreeViewItem;

            if (selectedItem != null)
            {
                // Verifica o texto do cabeçalho do item selecionado
                if (selectedItem.Header.ToString() == "Emitir relatório de consulta")
                {
                    // Abre a nova janela e fecha a atual
                    RelatorioConsulta relatorioConsulta = new RelatorioConsulta();
                    relatorioConsulta.Show();

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
                    RelatorioCaixa relatorioCaixa = new RelatorioCaixa();
                    relatorioCaixa.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                else if (selectedItem.Header.ToString() == "Emitir relatório de produto")
                {
                    RelatorioProduto relatorioProduto = new RelatorioProduto();
                    relatorioProduto.Show();

                    // Fecha a janela atual
                    this.Close();
                }
                else if (selectedItem.Header.ToString() == "Emitir relatório ")
                {
                    RelatorioOrcamento relatorioOrcamento = new RelatorioOrcamento();
                    relatorioOrcamento.Show();

                    // Fecha a janela atual
                    this.Close();
                }
            }
        }
    }
        
 
}
