using System;
using System.Collections.Generic;

namespace ROSARIOAPP.Models
{
    public partial class Matricula
    {
        public int Idmatricula { get; set; }
        public int Idestudiante { get; set; }
        public int Idmodalidad { get; set; }
        public int Idgrupo { get; set; }

        public int año_lectivo { get; set; }
        public string turno { get; set; }
        public string fecha_matricula { get; set; } 
        public string repitente { get; set; }
        public string tarjeta { get; set; }

        public string estado { get; set; }
        public string observacion { get; set; }


        public virtual Estudiante IdestudianteNavigation { get; set; }
 
        public virtual Modalidad IdmodalidadNavigation { get; set; }
        public virtual Grupo IdgrupoNavigation { get; set; }
        public virtual ICollection<Nota_Matricula> Nota_Matricula { get; set; }
    }

}
