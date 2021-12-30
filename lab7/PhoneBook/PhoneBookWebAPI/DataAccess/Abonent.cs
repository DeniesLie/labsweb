using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PhoneBook.DataAccess
{
    public class Abonent
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string Adress { get; set; }

        [ForeignKey("City")]
        public string CityIndex { get; set; }
        public City City { get; set; }

        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}