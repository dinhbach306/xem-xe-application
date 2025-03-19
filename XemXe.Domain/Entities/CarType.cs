using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XemXe.Domain.Entities;

[Table("CarTypes")]
public class CarType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(255)")]
    public string Name { get; set; }

    public List<CarModel> Models { get; set; } = new List<CarModel>();
}