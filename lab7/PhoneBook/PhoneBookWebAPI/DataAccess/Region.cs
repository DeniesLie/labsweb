using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PhoneBook.DataAccess
{
    public class Region
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        
        [JsonIgnore]
        public List<City> Cities { get; set; }
    }
}
