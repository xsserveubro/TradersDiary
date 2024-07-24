using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradersDiary.Models
{
    public abstract class Deal
    {
        public Guid Id { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Opening Date")]
        public DateTime OpeningDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Closing Date")]
        public DateTime? ClosingDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
    }
}
