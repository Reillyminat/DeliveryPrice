﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel
{
    public class Dimensions
    {
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }

        public Dimensions() { }
        public Dimensions(float height, float width, float length)
        {
            Height = height;
            Width = width;
            Length = length;
        }
    }
}