using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradersDiary.Models
{
    public class DealBO : Deal
    {
        public double Expiration { get; set; }
        public string? Direction { get; set; }
        public string? Result {  get; set; }
    }
}
