using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPICine.Data.Entities
{
    public class MovieEntity
    {
        [Required]
        [Key]
        public int id { get; set; }
       
        public string name { get; set; }
       
        public string imageLink { get; set; }

        public float valoracion { get; set; }
        public string genero { get; set; }
        public string director { get; set; }
        public string descripcion { get; set; }


        [ForeignKey("CineId")]
        public virtual CineEntity Cine { get; set; }
    }
}
