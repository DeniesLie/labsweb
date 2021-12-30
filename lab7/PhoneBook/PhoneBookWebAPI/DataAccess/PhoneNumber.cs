using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PhoneBook.DataAccess
{
    public class PhoneNumber
    {
        [Required]
        [MaxLength(12)]
        [Key]
        public string Number { get; set; }
        [JsonIgnore]
        public Abonent Abonent { get; set; }
        public int AbonentId { get; set; }
    }
}
