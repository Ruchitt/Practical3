using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical3.Models.ViewModels
{
    public class OrderItemVM
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
