namespace OauthWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(100)]
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
