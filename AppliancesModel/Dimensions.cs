using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliancesModel
{
    public class Dimensions
    {
        float Height { get; set; }
        float Width { get; set; }
        float Length { get; set; }

        public Dimensions(float height, float width, float length)
        {
            this.Height = height;
            this.Width = width;
            this.Length = length;
        }
    }
}
