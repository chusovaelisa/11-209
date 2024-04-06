using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockemonAPI22.DataAccess.Entities
{
    public class Pockemon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public int BrerdingId { get; set; }
        public Breeding Breeding { get; set; }
        public string Test { get; set; }
    }
}