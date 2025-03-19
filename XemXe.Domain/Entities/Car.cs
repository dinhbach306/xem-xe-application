using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XemXe.Domain.Entities;

[Table("Cars")]
public class Car
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("CarModel")]
    [Column("model_id")]
    public int ModelId { get; set; }

    [ForeignKey("Color")]
    [Column("color_id")]
    public int ColorId { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Required]
    public int Year { get; set; }

    [Column("is_available", TypeName = "bit")]
    public bool IsAvailable { get; set; } = true;

    public CarModel CarModel { get; set; }
    
    public Color Color { get; set; }
}