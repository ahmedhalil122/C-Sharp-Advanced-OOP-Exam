using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            this.type = type;
            this.capacity = capacity;
            clothes = new List<Cloth>();
        }

        public string type { get; set; }
        public int capacity { get; set; }
		public List<Cloth> clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (this.clothes.Count<this.capacity)
            {
                clothes.Add(cloth);

            }
        }

        public bool RemoveCloth(string color)
        {
            Cloth cloth = this.clothes.FirstOrDefault(c => c.color == color);
            if (cloth != null)
            {
                this.clothes.Remove(cloth);
                return true;
            }
            else return false;
        }
        public Cloth GetSmallestCloth()
        {
            return this.clothes.OrderBy(c => c.size).FirstOrDefault();
        }
        public Cloth GetCloth(string color)
        {
            return this.clothes.FirstOrDefault(c => c.color == color);
        }
        public int GetClothCount()
        {
            return this.clothes.Count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.type} magazine contains:");

            foreach (var cloth in this.clothes.OrderBy(c => c.size))
            {
                sb.AppendLine(cloth.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        }
}
