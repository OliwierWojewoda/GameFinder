using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Entities
{
    public class Role
    {
        [Key]
        public int Role_Id { get; set; }

        public string Name { get; set; }
    }
}
