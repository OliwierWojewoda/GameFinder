using GameFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Models
{
    public class NewGameDto
    {

        public int SportId { get;  set; }
        public DateTime Start { get;  set; }
        public DateTime PrecictedEnd { get;  set; }
        public int CourtId { get;  set; }
    }
}
