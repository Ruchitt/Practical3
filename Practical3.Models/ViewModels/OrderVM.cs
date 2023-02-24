using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NSwag.Annotations;

namespace Practical3.Models.ViewModels
{
    public class OrderVM
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerContactNo { get; set; }
        public double DiscountAmount { get; set; }
        public string Note { get; set; }
        public double TotalAmount { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
