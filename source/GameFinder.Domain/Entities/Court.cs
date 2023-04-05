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

        public string CourtType {  get; private set; }


        private Court(int addressId, string courtType)
        {
            AddressId = addressId;
            CourtType = courtType;
        }
        /// <summary>
        /// Create new instance of Court entity
        /// </summary>
        /// <param name="addressId"></param>
        public static Court New(int addressId, string courtType) => new Court(addressId,courtType);
    }
}
