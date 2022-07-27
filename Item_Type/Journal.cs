using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Type
{
    public class Journal : LibraryItem, IFormattable
    {

        public static List<string> JournalGanres = new List<string>();

        public List<string> Contributers { get; private set; }
        public List<string> Editors { get; private set; }
        public JournalFrequency KnownFrequency { get; set; }
        public List<string> Frequency { get; private set; }
        public string Summary { get; set; }

        public Journal(string title, DateTime publishDate , double price , int qauntity=1)
            : base(title, publishDate , price , qauntity)
        {
            Contributers = new List<string>();
            Editors = new List<string>();
            Frequency = new List<string>();
        }

        public override string ToString()
        {
            return base.ToString() + $"| Editors: {string.Join("|", Editors)} | Frequency: {string.Join("|", Frequency)}\t" +
                $"\n----------------------------------------------------------------------------------------------------------------------";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "Editor":
                    return $"{string.Join("|", Editors)}";
                case "Contributer":
                    return $"{string.Join("|", Contributers)}";
                case "Frequency":
                    return $"{string.Join("|", Frequency)}";
                default:
                    return this.ToString();
            }
        }
    }

    public enum JournalFrequency
    {
        Daily,
        Weekly,
        BiWeekly,
        Monthly,
        BiMonthly,
        Qurterly,
        SemiAnnualy,
        Annualy,
        BiAnnualy,
        Other
    }
  
}
