using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ROSARIOAPP.Models
{
    public class Asignar
    {
        //Definir yave primaria
        [Key]
        public int Idasignar { get; set; }
        public int Iddocente { get; set; }

        public int Idgrupo { get; set; }

        //sbyte tipo de dato Tinyin en SQL
        public sbyte tutor { get; set; }

   

        //Referencia con la tabla docente y de grupo 

        public virtual Docente IddocenteNavigation { get; set; }
        public virtual Grupo IdgrupoNavigation { get; set; }
   



    }
}
