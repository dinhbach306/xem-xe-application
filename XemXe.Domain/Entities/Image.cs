using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XemXe.Domain.Entities;

[Table("Images")]
public class Image
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Url { get; set; } // URL của ảnh trên S3

    [ForeignKey("Car")]
    public int CarId { get; set; }

    public virtual Car Car { get; set; }   
}