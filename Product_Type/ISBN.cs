using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Type
{
    public class ISBN
    {

        private const int _prefix = 979;
        public static Dictionary<string, int> Countries { get; set; }
        public static Dictionary<string, int> Publishers { get; set; }

        private string _country;
        private string Country
        {
            get { return _country; }
            set
            {
                if (!Countries.ContainsKey(value))
                    throw new ArgumentException($"Country '{value}' Is Not In ISBN");
                _country=value;
            }
        }


        private string _publisher;
        private string Publisher
        {
            get { return _publisher; }
            set
            {
                if (!Publishers.ContainsKey(value))
                    throw new ArgumentException($"Publisher '{value}' Is Not In ISBN");
                _publisher=value;
            }
        }


        public int SerialNumber { get; set; }

        public int Check_Digit { get { return (Countries[Country]+Publishers[Publisher] + SerialNumber) %10; } set {; } }


        public override string ToString()
        {
            return $"{_prefix}-{Countries[Country].ToString("D3")}-{Publishers[Publisher].ToString("D3")}-{SerialNumber.ToString("D3")}-{Check_Digit}";
        }
    }
}
