namespace AppliancesModel
{
    public class Dimensions
    {
        public float Height { get; set; }

        public float Width { get; set; }

        public float Length { get; set; }

        public Dimensions(float height, float width, float length)
        {
            Height = height;
            Width = width;
            Length = length;
        }
    }
}
