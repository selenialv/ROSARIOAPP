using System;
using System.Collections.Generic;

namespace ROSARIOAPP.Models
{
    public partial class Materia
    {
      
        
        public int Idmateria { get; set; }
        public int Iddocente { get; set; }
        public string Nombre { get; set; }


        public virtual Docente IddocenteNavigation { get; set; }

        //Referencia con la tabla Materia_Grado
        //Relacion muchos a muchos
        public virtual ICollection<Nota> Nota { get; set; }
        public virtual ICollection<Materia_Grado> Materia_Grado { get; set; }

    }
}
