using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Entities
{
    public class Game
    {
        [Key]
        public int Game_Id { get; set; }

        public int Sport_Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Precicted_End { get; set; }
        public int Court_Id { get; set; }
    }
}
