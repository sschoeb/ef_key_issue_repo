﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCompositeKeyTest.DataModel
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int TenantId { get; set; }

        public string Name { get; set; }

        public int? OrderId { get; set; }

        public Order Order { get; set; }
    }
}