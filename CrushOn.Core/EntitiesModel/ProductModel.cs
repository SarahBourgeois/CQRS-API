using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrushOn.Core.EntitiesModel
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
