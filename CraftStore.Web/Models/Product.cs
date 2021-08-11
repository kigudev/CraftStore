using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CraftStore.Web.Models
{
    public class Product
    {
        public string Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Maker { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }

        [MaxLength(200)]
        [Required]
        public string Url { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Description { get; set; }

        //public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}