using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class UserItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

       [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


        [ForeignKey("IdRol")]
        public int IdRol { get; set; }
    }
}
