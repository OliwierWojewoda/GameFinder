using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Entities
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public int Name { get; set; }
    }
}
