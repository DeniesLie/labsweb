using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PhoneBook.DataAccess
{
    [Table("Cities")]
    public class City
    {
        [Key]
        [MaxLength(5)]
        public string Index { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Region Region { get; set; }
        public int RegionId { get; set; }
        [JsonIgnore]
        public List<Abonent> Abonents { get; set; }
    }
}
