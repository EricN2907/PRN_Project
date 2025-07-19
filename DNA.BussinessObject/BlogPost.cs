using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNA.BussinessObject
{
    public class BlogPost
    {
        [Key]
        public int PostId { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        public string Slug { get; set; } = string.Empty;
        
        [Required]
        public string Content { get; set; } = string.Empty;
        
        public string Summary { get; set; } = string.Empty;
        
        public string ImageUrl { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? FeaturedImage { get; set; }
        
        public string Category { get; set; } = string.Empty;
        
        public string Tags { get; set; } = string.Empty;
        
        public int AuthorId { get; set; }
        
        public bool IsPublished { get; set; } = false;
        
        [StringLength(20)]
        public string Status { get; set; } = "Draft"; // Draft, Published, Archived
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? PublishedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        public int ViewCount { get; set; } = 0;
        
        // Navigation properties
        public virtual User Author { get; set; } = null!;
    }
}
