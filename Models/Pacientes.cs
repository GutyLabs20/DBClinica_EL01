using System;
using System.Collections.Generic;

namespace DBClinica_EL01.Models
{
    public partial class Pacientes
    {
        public Pacientes()
        {
            Citas = new HashSet<Citas>();
        }

        public string Codpac { get; set; }
        public string Nompac { get; set; }
        public string Dnipac { get; set; }
        public string TelCel { get; set; }
        public string Dirpac { get; set; }
        public string Coddis { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<Citas> Citas { get; set; }
    }
}
