using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradersDiary.Models
{
    public class Deal
    {
        public Guid Id { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Opening Date")]
        public DateTime OpeningDate { get; set; }
        public double Expiration { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Closing Date")]
        public DateTime ClosingDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
        public string? Direction { get; set; }
        public string? Result {  get; set; }
    }
}
