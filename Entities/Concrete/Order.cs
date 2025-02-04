﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmloyeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }
    }
}
