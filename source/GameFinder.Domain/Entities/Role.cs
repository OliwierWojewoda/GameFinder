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
        public int RoleId { get; private set; }

        public string Name { get; private set; }

        public Role(int roleId, string name)
        {
            RoleId = roleId;
            Name = name;
        }
    }
}
