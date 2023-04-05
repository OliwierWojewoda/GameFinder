using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; private set; }

        public string Name { get; private set;}
        public string Surname { get; private set;}
        public DateTime Birthday { get; private set; }
        public string Email { get; private set;}
        public string PasswordHash { get; private set;}
        public string Phone { get; private set;}
        public int RoleId { get; private set; }
        public virtual Role RoleRole { get; private set; }

    }
}
