using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityCoreWebApi.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
