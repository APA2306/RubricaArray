using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anelli.Alessandro._4I.Rubrica
{
    internal class Contatto
    {
        private int numero;
        private string nome;
        private string cognome;
        private string email;
        private string telefono;

        public int Numero { get => numero; set => numero = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cognome { get => cognome; set => cognome = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
