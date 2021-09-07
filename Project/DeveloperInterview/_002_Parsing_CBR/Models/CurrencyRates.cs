using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Parsing_CBR.Models
{
    public class CurrencyRates
    {
        public int DigitCode { get; set; }
        public string LettersCode { get; set; }
        public int Units { get; set; }
        public string Currency { get; set; }
        public float Course { get; set; }

        public static void AddCource(CurrencyRates currencyRates)
        {
            return;
        }

        public static List<CurrencyRates> HelperByHtmlTabls(string tableHtml)
        {
            var rows = tableHtml.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            List<string> model = new List<string>();
            List<CurrencyRates> CurrencyRates = new List<CurrencyRates>();

            foreach (var item in rows)
            {
                if (item.IndexOf("<td>") >= 0)
                {
                    var tmp = item.Trim();
                    var currencyRatesValue = tmp.Substring(4, tmp.IndexOf("</td>") - 4);
                    model.Add(currencyRatesValue);
                    continue;
                }

                if (model.Count == 5)
                {
                    CurrencyRates.Add(new CurrencyRates()
                    {
                        DigitCode = int.Parse(model[0]),
                        LettersCode = model[1],
                        Units = int.Parse(model[2]),
                        Currency = model[3],
                        Course = float.Parse(model[4])
                    });
                    model.Clear();
                }
            }

            return CurrencyRates;
        }
    }

}
