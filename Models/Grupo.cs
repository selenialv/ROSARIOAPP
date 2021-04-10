using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ROSARIOAPP.Models
{
    public partial class Grupo
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Idgrupo { get; set; }
        public int Idgrado  { get; set; }
     

        public string seccion { get; set; }


        [NotMapped]
        public string Fullgrupo
            {
                get
                {
                return seccion + "-" + Idgrado;
                }        
            }

        public virtual Grado IdgradoNavigation  { get; set; }
        public virtual ICollection<Matricula> Matricula { get; set; }
        public virtual ICollection<Asignar> Asignar { get; set; }

       
    }
}
