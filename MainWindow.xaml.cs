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

namespace Anelli.Alessandro._4I.Rubrica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            contatto c = new contatto();
            c.Numero = 1;
            c.Nome = "Alessandro";
            c.Cognome = "Anelli";

            contatto[] contatti = new contatto[100];
            contatti[0] = c;

            contatti[0].Nome = "Samir";
            contatti[0].Cognome = "Rame";
        }
    }
}
