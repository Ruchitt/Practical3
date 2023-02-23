using System.ComponentModel.DataAnnotations;

namespace IdentityCoreWebApi.Models
{
    public class Response
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public string Meessage { get; set; }
    }
}
