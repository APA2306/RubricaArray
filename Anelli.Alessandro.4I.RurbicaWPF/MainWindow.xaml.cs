using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Anelli.Alessandro._4I.RurbicaWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            const int MAX = 100;
            int idx = 0;
            try
            {
                Contatto[] Contatti = new Contatto[MAX];

                StreamReader sr = new StreamReader("Dati.csv");
                sr.ReadLine();
                string riga = string.Empty;

                while (!sr.EndOfStream && idx < MAX)
                {
                    riga = sr.ReadLine();
                    Contatti[idx] = new Contatto(riga);
                    idx++;
                }

                while (idx < MAX)
                    Contatti[idx++] = new Contatto();

                idx = 0;

                gdDati.ItemsSource = Contatti;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nErrore alla riga: {idx}!");
            }

            int valore;
        }

        private void gdDati_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            Contatto c = e.Row.Item as Contatto;
            if (c != null)
            {
                if (c.PK == 0)
                {
                    e.Row.Background = Brushes.Red;
                    e.Row.Foreground = Brushes.White;
                }

                if (c.Telefono != null && c.Telefono.StartsWith("3"))
                {
                    e.Row.Background = Brushes.Yellow;
                }
            }

        }
    }
}