using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XemXe.Domain.Entities;

[Table("CarModels")]
public class CarModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("Manufacturer")]
    [Column("manufacturer_id")]
    public int ManufacturerId { get; set; }

    [ForeignKey("CarType")]
    [Column("type_id")]
    public int CarTypeId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(255)")]
    public string Name { get; set; }

    [Required]
    [Column("base_price", TypeName = "decimal(18,2)")]
    public decimal BasePrice { get; set; }

    public Manufacturer Manufacturer { get; set; }
    public CarType CarType { get; set; }
    public List<Car> Cars { get; set; } = new List<Car>();
}