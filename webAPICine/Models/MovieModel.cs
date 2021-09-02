using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPICine.Models
{
    public class MovieModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imageLink { get; set; }

        public float valoracion { get; set; }
        public string genero { get; set; }
        public string director { get; set; }
        public string descripcion { get; set; }


        public int CineId { get; set; }
    }
}
