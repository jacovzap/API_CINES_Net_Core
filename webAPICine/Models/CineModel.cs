using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPICine.Models
{
    public class CineModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string imageLink { get; set; }
        public IEnumerable<MovieModel> Movies { get; set; }

    }
}
