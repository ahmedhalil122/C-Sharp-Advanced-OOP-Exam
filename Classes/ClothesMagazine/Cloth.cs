namespace ClothesMagazine
{
    public class Cloth
    {
		public string color { get; set;}
        public int size { get; set; }
        public string type { get; set; }

        public Cloth(string color, int size, string type)
        {
			this.color = color;
			this.size = size;
			this.type = type;
        }   
        public override string ToString()
		{
			return $"Product: {type} with size {size}, color {color}";

        }




	}
}
