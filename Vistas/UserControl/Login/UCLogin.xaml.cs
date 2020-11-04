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

namespace Vistas.UserControl
{
    /// <summary>
    /// Lógica de interacción para UCLogin.xaml
    /// </summary>
    public partial class UCLogin 
    {
        public UCLogin()
        {
            InitializeComponent();
        }

        public string Usuario
        {
            get { return txtbUsuario.Text; }

        }

        public string Contraseña
        {
            get { return txtbContraseña.Password; }
        }
    }
}
