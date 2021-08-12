using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CraftStore.Web.Models
{
    public class Product
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Maker { get; set; }

        [JsonPropertyName("img")]
        [Url]
        public string Image { get; set; }

        [MaxLength(100)]
        [Required]
        [Url]
        [Display(Name = "Site URL")]
        public string Url { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Description { get; set; }

        //public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}