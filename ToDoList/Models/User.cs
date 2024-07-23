using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(128)]
        public string Salt { get; set; }

        public virtual ICollection<Project> OwnedProjects { get; set; }
        public virtual ICollection<Project> SharedProjects { get; set; }
    }
}
