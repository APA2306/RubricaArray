# RubricaWPF

Programma che legge un file .csv contenente una riga per ogni contatto salvato.

```csv
PK;Nome;Cognome;Telefono;Email;
1;Maurizio;Conti;3516856987;Conti@gmail.com;
2;Alessandro;Anelli;3755607057;Anelli@gmail.com;
3;Davide;Bernardi;1349660321;Bernardi@gmail.com;
```
Il programma divide ogni dato del contatto fra PK,nome,cognome,telefono e email con un array e li mostra a video. Se incontra un contatto con errore non stampa la riga mentre le righe vuote vengono colorate di rosso mentre le righe che hanno la variabile telefono che inizia per 3 vengono colorate di giallo.

# Classe contatto

```c#
internal class Contatto
    {
        private int _PK;
        private string _cognome;
        private string _telefono;
        private string _Email;

        public Contatto() { }

        public Contatto(string r)
        {
            string[] values = r.Split(';');
            if (values.Length >= 5)
            {
                if (int.TryParse(values[0], out int res))
                {
                    this._PK = res;
                    this.Nome = values[1];
                    this.Cognome = values[2];
                    this.Telefono = values[3];
                    this.Email = values[4];
                }
                else
                {
                    this._PK = 0;
                }
            }
        }
        public int PK { get => this._PK; }
        public string Nome { set; get; }
        public string Cognome
        {
            get => _cognome;
            set => _cognome = value;
        }

        public string Email { get => _Email; set => _Email = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
    }
```

Qua sopra si puo notare la divisione del contatto in un array con la riga "string[] values = r.Split(';');"

# Classe Main

```c#
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
```
Si può notare che abbiamo messo tutto il codide in un metodo "Window loaded" e non nel main, cosi che queste azione avvengano appena si avvia il programma.
