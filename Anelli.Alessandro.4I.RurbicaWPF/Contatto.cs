using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anelli.Alessandro._4I.RurbicaWPF
{
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
}
