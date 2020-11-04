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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClasesBase;


namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipalMain.Children.Clear();
            panelPrincipalMain.Children.Add(new UserControl.Cliente.UCCliente());
        }

        private void BtnTickets_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipalMain.Children.Clear();
            panelPrincipalMain.Children.Add(new UserControl.Ticket.UCTicket());
        }

        private void BtnUsuario_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipalMain.Children.Clear();
            panelPrincipalMain.Children.Add(new UserControl.Usuario.UCUsuario());
        }

        private void BtnPelicula_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipalMain.Children.Clear();
            panelPrincipalMain.Children.Add(new UserControl.Pelicula.UCPelicula());
        }

        private void BtnButaca_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipalMain.Children.Clear();
            panelPrincipalMain.Children.Add(new UserControl.Butaca.UCButaca());
        }

        private void BtnProyecciones_Click(object sender, RoutedEventArgs e)
        {
            panelPrincipalMain.Children.Clear();
            panelPrincipalMain.Children.Add(new UserControl.Proyeccion.UCProyeccion());
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            WPFLogin login = new WPFLogin();
            deslogearUsuario();
            Close();
            login.Show();
        }

        private void deslogearUsuario()
        {
            UsuarioLogin.rol_Codigo = -1;
            UsuarioLogin.usu_ApellidoNombre = null;
            UsuarioLogin.usu_Id = -1;
            UsuarioLogin.usu_NombreUsuario = null;
            UsuarioLogin.usu_Password = null;
        }
    }
}
