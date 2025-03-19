using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XemXe.Domain.Entities;

[Table("Manufacturers")]
public class Manufacturer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "nvarchar(255)")]
    public string Name { get; set; }
    
    [Column(TypeName = "nvarchar(100)")]
    public string Country { get; set; }
    
    public List<CarModel> Models { get; set; } = new List<CarModel>();
}