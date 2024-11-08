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
    /// Lógica interna para RecuperarSenha1.xaml
    /// </summary>
    public partial class RecuperarSenha1 : Window
    {
        public RecuperarSenha1()
        {
            InitializeComponent();
        }

        private void Voltar_Button_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void Senha2_Button_Click(object sender, RoutedEventArgs e)
        {
            RecuperarSenha2 s2 = new RecuperarSenha2();
            s2.Show();
            this.Close();
        }
    }
}
