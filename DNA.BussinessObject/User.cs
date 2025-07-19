using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DNA.BussinessObject
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;
        
        [StringLength(20)]
        public string? Phone { get; set; }
        
        [StringLength(500)]
        public string? Address { get; set; }
        
        [Required]
        [StringLength(20)]
        public string UserType { get; set; } = "Customer"; // Guest, Customer, Staff, Manager, Admin
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        public DateTime? LastLoginDate { get; set; }

        // Navigation properties
        public virtual ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    }
}
