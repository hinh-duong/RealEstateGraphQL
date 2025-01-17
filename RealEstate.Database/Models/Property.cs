﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Database.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }
        public string Family { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
