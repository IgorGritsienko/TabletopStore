﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopStore
{
    public class TabletopGame
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
        public string? Description { get; set; }
    }
}
