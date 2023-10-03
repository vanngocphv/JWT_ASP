using System.ComponentModel.DataAnnotations;

namespace ASP_JWT.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
