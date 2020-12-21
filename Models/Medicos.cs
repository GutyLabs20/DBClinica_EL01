using System;
using System.Collections.Generic;

namespace DBClinica_EL01.Models
{
    public partial class Medicos
    {
        public Medicos()
        {
            Citas = new HashSet<Citas>();
        }

        public string Codmed { get; set; }
        public string Codesp { get; set; }
        public string Nommed { get; set; }
        public int? AnioColegio { get; set; }
        public string Coddis { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<Citas> Citas { get; set; }
    }
}
