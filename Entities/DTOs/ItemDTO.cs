﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? Amount { get; set; }
        public int GroupId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Selected { get; set; }
    }
}
