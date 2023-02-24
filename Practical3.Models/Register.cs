using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IdentityCoreWebApi.Models
{
    public class Register
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage ="Username is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
