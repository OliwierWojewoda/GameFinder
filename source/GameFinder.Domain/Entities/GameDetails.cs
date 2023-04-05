using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Entities
{
    public class GameDetails
    {
        [Key]
        public int GameDetailsId { get; private set; }

        public int GameId { get; private set; }
        public virtual Game Game { get; private set; }
        public int UserId { get; private set; }
        public virtual User User { get; private set; }
    }
}
