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
        public int Iddocente { get; set; }
        public Docente docente { get; set; }

        public Grupo grupo { get; set; }

        public int Idgrupo { get; set; }

        //sbyte tipo de dato Tinyin en SQL
        public sbyte tutor { get; set; }


    }
}
