using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Entities
{
    public class Address
    {
        [Key]
        public int Address_Id { get; private set; }
        
        public string City { get; private set; }

        public string Street { get; private set; }

        public string Postal_Code { get; private set; }
        
        public Address(string city, string street, string postal_code)
        {
            City= city;
            Street= street;
            Postal_Code= postal_code;
        }

        /// <summary>
        /// Create new instance of Address entity
        /// </summary>
        /// <param name="name"></param>
        public static Address New(string city, string street, string postal_code) => new Address(city, street, postal_code);
        

    }
}
