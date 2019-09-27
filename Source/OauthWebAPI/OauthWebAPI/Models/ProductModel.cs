using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OauthWebAPI.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Stock { get; set; }
        public int? Sell_Price { get; set; }
        public int? Buy_Price { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }
    }
}