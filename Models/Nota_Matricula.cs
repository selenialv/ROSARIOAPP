using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROSARIOAPP.Models
{
    public class Nota_Matricula
    {
        public int Idnota { get; set; }

        public Nota Nota { get; set; }
        public int Idmatricula  { get; set; }
        public Matricula Matricula { get; set; }


       
    }

}
