using System;
using System.Collections.Generic;

namespace ROSARIOAPP.Models
{
    public partial class Grado
    {
        public Grado()
        {
           Grupo = new HashSet<Grupo>();
          
          
        }

        public int Idgrado { get; set; }
        public string Grado1 { get; set; }


        public virtual ICollection<Materia_Grado> Materia_Grado { get; set; }
        public virtual ICollection<Grupo> Grupo { get; set; }
       
        }
}

