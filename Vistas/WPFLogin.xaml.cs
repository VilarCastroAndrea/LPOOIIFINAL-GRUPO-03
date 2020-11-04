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
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WPFLogin.xaml
    /// </summary>
    public partial class WPFLogin : Window
    {
        public WPFLogin()
        {
            InitializeComponent();
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (TrabajarUsuario.validarUsuario(login.Usuario, login.Contraseña) == true)
            {
                MainWindow menu = new MainWindow();
                menu.Show();
                Close();
            }
            else
            {
                MessageBox.Show("No se encontro el usuario " + login.Usuario, "Error");
            }
        }
    }
}
