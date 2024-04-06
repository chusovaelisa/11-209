using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PockemonAPI22.DataAccess.Entities
{
    public class Breeding
    {
        [Key] public int Id { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
    }
}