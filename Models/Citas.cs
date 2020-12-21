using System;
using System.Collections.Generic;

namespace DBClinica_EL01.Models
{
    public partial class Citas
    {
        public int Nrocita { get; set; }
        public string Codmed { get; set; }
        public string Codpac { get; set; }
        public decimal Pago { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public string Descrip { get; set; }

        public virtual Medicos CodmedNavigation { get; set; }
        public virtual Pacientes CodpacNavigation { get; set; }
        //Cuando tiene el signo de interrogación es define como el campo
        //puede aceptar valores nulos -> NULL
    }
}
