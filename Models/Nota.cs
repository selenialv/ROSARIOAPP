using System;
using System.Collections.Generic;

namespace ROSARIOAPP.Models
{
    public partial class Nota
    {
        public int Idnota { get; set; }
        public int Idmateria { get; set; }
        public string parcial { get; set; }
        public string corte_evaluativo { get; set; }
        public string nota_final { get; set; }


        //Relacion muchos a muchos
        public virtual ICollection<Nota_Matricula> Nota_Matricula { get; set; }
        public virtual Materia IdmateriaNavigation { get; set; }
    }
}
