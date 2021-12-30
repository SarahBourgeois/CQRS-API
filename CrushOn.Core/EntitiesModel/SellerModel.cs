using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace CrushOn.Core.EntitiesModel
{
    public class SellerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string StoreName { get; set; }
        public string Email { get; set; }

        public static implicit operator Task<object>(SellerModel v)
        {
            throw new NotImplementedException();
        }
    }
}
