using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,double>dots=new Dictionary<string, double>()
            {
                {"xa",0.0 },
                {"ya",0.0 },
                {"xb",0.0 },
                {"yb",0.0 },
                {"xc",0.0 },
                {"yc",0.0 }
            };
            Dictionary<string, double> longitude = new Dictionary<string, double>()
            {
                {"ab",0.0 },
                {"bc",0.0 },
                {"ac",0.0 }
            };
            List<string> list = new List<string>(longitude.Keys);
            List<string> keys = new List<string>(dots.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                string key = keys[i];
                Console.WriteLine("Enter coordinate " + key.ToUpper()[0] + " of dot " + key.ToUpper()[1] + ":");
                dots[key] = double.Parse(Console.ReadLine());
            }
            for (int i = 0; i < list.Count; i++)
            {
                string key = list[i];
                longitude[key] = Math.Sqrt(Math.Pow(dots["x" + key[1]] - dots["x" + key[0]], 2) + Math.Pow(dots["y" + key[1]] - dots["y" + key[0]], 2));
            }

            Console.WriteLine("The triangle is"+ (isEquilateral(longitude) ? "" : " NOT") + " Equilateral");

            Console.WriteLine("The triangle is"+(isIsosceles(longitude)?"":" NOT")+ " Isosceles");

            Console.WriteLine("The triangle is" + (isRight(longitude) ? "" : " NOT ") + " right");

            Console.WriteLine("The length of each side is:");
            foreach (KeyValuePair<string, double> element in longitude)
            {
                Console.WriteLine("{0}: {1}", element.Key.ToUpper(), element.Value);
            }
            double perimeter = longitude["ab"] + longitude["bc"] + longitude["ac"];
            Console.WriteLine("Perimeter of triangle: {0}", perimeter);

            Console.WriteLine("Even numbers from 0 to {0}:", perimeter);
            for (int i = 0; i <= perimeter; i += 2)
            {
                Console.Write("{0} ", i);
            }
            Console.ReadLine();
        }
        
        public static bool isEquilateral(Dictionary<string, double> longitude)
        {
            return longitude["ab"] == longitude["bc"] && longitude["bc"] == longitude["ac"];
        }

        public static bool isIsosceles(Dictionary<string, double> longitude)
        {
            return longitude["ab"] == longitude["bc"] || longitude["bc"] == longitude["ac"] || longitude["ac"] == longitude["ab"];
        }

        public static bool isRight(Dictionary<string, double> longitude)
        {
            return (Math.Abs(Math.Pow(longitude["bc"], 2) - (Math.Pow(longitude["ab"], 2) + Math.Pow(longitude["ac"], 2))) <= 0.01) || (
                Math.Abs(Math.Pow(longitude["ab"], 2) - (Math.Pow(longitude["bc"], 2) + Math.Pow(longitude["ac"], 2))) <= 0.01) || (
                Math.Abs(Math.Pow(longitude["ac"], 2) - (Math.Pow(longitude["ab"], 2) + Math.Pow(longitude["bc"], 2))) <= 0.01);
        }
    }
}
