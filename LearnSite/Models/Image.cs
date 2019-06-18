using System.ComponentModel.DataAnnotations;

namespace LearnSite.Models
{
    public class Image
    {
        [Required] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public byte[] Data { get; set; }

        [Required] public int Length { get; set; }

        [Required] public int Width { get; set; }

        [Required] public int Height { get; set; }

        [Required] public string ContentType { get; set; }
    }
}