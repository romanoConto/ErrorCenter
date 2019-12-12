using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Codenation.ErrorCenter.Models.Models
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }

        [Column("name")]
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Column("email")]
        [StringLength(255)]
        [Required]
        public string Email { get; set; }

        [Column("password")]
        [StringLength(255)]
        [Required]
        public string Password { get; set; }

        [Column("token")]
        [StringLength(1000)]
        public string Token { get; set; }
    }
}
