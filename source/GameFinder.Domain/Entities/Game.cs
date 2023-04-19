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
        public int GameId { get; private set; }

        public int SportId { get; private set; }
        public virtual Sport Sport { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime PrecictedEnd { get; private set; }
        public int CourtId { get; private set; }
        public virtual Court Court { get; private set; }

        public Game(int sportId, DateTime start, DateTime precictedEnd, int courtId)
        {
            SportId = sportId;
            Start = start;
            PrecictedEnd = precictedEnd;
            CourtId = courtId;
        }
    }
}
