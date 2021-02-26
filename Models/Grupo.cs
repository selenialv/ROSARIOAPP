using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROSARIOAPP.Models
{
    public partial class Grupo
    {
       
        public int Idgrupo { get; set; }
        public int Idgrado { get; set; }
        public int seccion { get; set; }

        public virtual Grado IdgradoNavigation { get; set; }
        public virtual ICollection<Matricula> Matricula { get; set; }
        public virtual ICollection<Asignar> Asignar { get; set; }
    }
}
