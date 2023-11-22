using System;
using System.Collections.Generic;
using System.IO;
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

            StreamReader reader = new StreamReader("dati.csv");

            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string riga = reader.ReadLine();
                if (!string.IsNullOrWhiteSpace(riga))
                {
                    string[] valore = riga.Split(';');
                    Contatto c = new Contatto();

                    if (valore.Length == 5)
                    {
                        int val = 0;
                        int.TryParse(valore[0], out val);
                        c.Numero = val;
                        c.Nome = valore[1];
                        c.Cognome = valore[2];
                        c.Email = valore[3];
                        c.Telefono = valore[4];
                    }
                }
            }
        }
    }
}

