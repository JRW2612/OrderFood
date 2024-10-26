﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.DataModels
{
    public class ReviewMasterModel
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int CustomerId { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }
    }
}
