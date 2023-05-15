using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Models
{
    public class LoggedUserDto
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }
}
