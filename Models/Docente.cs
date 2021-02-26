using System;
using System.Collections.Generic;


namespace ROSARIOAPP.Models
{
    public partial class Docente
    {
        public Docente()
        {
            Materia = new HashSet<Materia>();
           
        }

        public int Iddocente { get; set; }
  
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string Cedula { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }

      
        public string Profesion { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Materia> Materia { get; set; }
        public virtual ICollection<Asignar> Asignar { get; set; }



    }
}

