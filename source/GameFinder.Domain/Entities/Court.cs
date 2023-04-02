using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Entities
{
    public class Court
    {
        [Key]
        public int Court_Id { get; set; }

        public int City_Id { get; set; }
    }
}
