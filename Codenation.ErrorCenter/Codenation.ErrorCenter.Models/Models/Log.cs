using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.ErrorCenter.Models.Models
{
    [Table("log")]
    public class Log
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("description")]
        [StringLength(255)]
        [Required]
        public string Description { get; set; }

        [Column("origin")]
        [StringLength(255)]
        [Required]
        public string Origin { get; set; }

        [Column("level")]
        [StringLength(255)]
        [Required]
        public string Level { get; set; }

        [Column("data")]
        [StringLength(2000)]
        [Required]
        public string Data { get; set; }

        [Column("environment")]
        [StringLength(255)]
        [Required]
        public string Environment { get; set; }

        [Column("frequency")]
        [Required]
        public int Frequency { get; set; }

        [Column("date")]
        [Required]
        public string Date { get; set; }
        
        [Column("isArchived")]
        [Required]
        public bool IsArchived { get; set; }
    }
}
