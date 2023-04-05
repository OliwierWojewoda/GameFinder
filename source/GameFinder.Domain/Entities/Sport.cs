using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Entities
{
    public class Sport
    {
        [Key]
        public int SportId { get; private set; }

        public string Name { get; private set; }

        public Sport(int sportId, string name)
        {
            SportId = sportId;
            Name = name;
        }
    }
}
