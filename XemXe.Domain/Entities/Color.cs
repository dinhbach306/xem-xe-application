using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XemXe.Domain.Entities;

[Table("Colors")]
public class Color
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(255)")]
    public string Name { get; set; }

    public List<Car> Cars { get; set; } = new List<Car>();
}