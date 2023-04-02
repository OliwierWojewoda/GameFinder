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
        public int User_Id { get; set; }

        public string Name { get; set;}
        public string Surname { get; set;}
        public DateOnly Birthday { get; set; }
        public string Email { get; set;}
        public string Password_Hash { get; set;}
        public string Phone { get; set;}
        public int Role_Id { get; set; }

    }
}
