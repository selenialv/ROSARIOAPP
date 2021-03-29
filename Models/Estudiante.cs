    using System;
using System.Collections.Generic;

namespace ROSARIOAPP.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Matricula = new HashSet<Matricula>();
    
        }

        public int Idestudiante { get; set; }
        public string codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
       
        public string fecha_nac { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
     
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Matricula> Matricula { get; set; }
       
    }
}
