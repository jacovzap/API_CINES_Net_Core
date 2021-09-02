using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPICine.Data.Entities
{
    public class CineEntity
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string location { get; set; }
        public string imageLink { get; set; }
        public virtual ICollection<MovieEntity> Movies { get; set; }
    }
}
