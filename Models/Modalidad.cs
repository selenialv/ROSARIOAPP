using System;
using System.Collections.Generic;

namespace ROSARIOAPP.Models
{
    public partial class Modalidad
    {
        public Modalidad()
        {
           
            Matricula = new HashSet<Matricula>();
        }

        public int Idmodalidad { get; set; }
        public string Modalidad1 { get; set; }


        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
