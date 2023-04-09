﻿using System;
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
        public int GameId { get;  set; }

        public int SportId { get;  set; }
        public virtual Sport Sport { get;  set; }
        public DateTime Start { get;  set; }
        public DateTime PrecictedEnd { get;  set; }
        public int CourtId { get;  set; }
        public virtual Court Court { get;  set; }

        
    }
}
