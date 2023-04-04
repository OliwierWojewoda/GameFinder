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
        public int Court_Id { get; private set; }

        public int Address_Id { get; private set; }
        
        private Court(int addressId)
        {
            Address_Id = addressId;
        }
        /// <summary>
        /// Create new instance of Court entity
        /// </summary>
        /// <param name="addressId"></param>
        public static Court New(int addressId) => new Court(addressId);
    }
}
