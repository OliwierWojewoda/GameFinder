using GameFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Models
{
    public class NewCourtDto
    {
        public string City { get;  set; }

        public string Street { get;  set; }

        public string Postal_Code { get;  set; }

        public string CourtType { get; set; }

    }
}
