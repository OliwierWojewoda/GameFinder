using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Entities
{
    public class Game_Details
    {
        [Key]
        public int Game_Details_Id { get; set; }

        public int Game_Id { get; set; }
        public int User_Id { get; set; }
    }
}
