using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ROSARIOAPP.Models
{
    public class Materia_Grado
    {

        //Tabla generada por relacion mucho a muchos
        public Grado Grado { get; set; }
        public int Idgrado { get; set; }

        public Materia materia { get; set; }
        public int Idmateria { get; set; }

        // Sbyte Tipo de dato Tinyin en SQL
        public sbyte tutor { get; set; }

      
    }
}
