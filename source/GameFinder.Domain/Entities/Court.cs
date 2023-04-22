using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Entities
{
    public class Court
    {
        [Key]
        public int CourtId { get; private set; }

        public int AddressId { get; private set; }

        public virtual Address Address { get; private set; }

        public virtual List<Game>? Games { get; private set; }

        public string CourtType {  get; private set; }


        private Court(string courtType)
        {
            CourtType = courtType;       
        }
        /// <summary>
        /// Create new instance of Court
        /// </summary>
        /// <param name="addressId"></param>
        public static Court New(string courtType, Address address)
        {
            var result =  new Court(courtType);
            result.SetAddress(address);
            return result;
        }

        public void SetAddress(Address address) => Address = address;

        public bool HasGames() => Games != null || Games.Count != 0;
    }
}
