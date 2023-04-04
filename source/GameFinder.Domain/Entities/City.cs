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
        public int CityId { get; private set; }
        
        public string Name { get; private set; }

        /// <summary>
        /// Create new instance of City entity
        /// </summary>
        /// <param name="name"></param>
        public static City New(string name)
        {
            return new City()
            {
                Name = name
            };
        }
    }
}
