namespace COMPANY.Application.Models.General.Dashboard
{
    using System.Collections.Generic;

    public class ChartData
    {
        public ChartData()
        {
            Labels = new List<string>();
            Serie = new List<decimal>();
        }

        public List<string> Labels { get; private set; }
        public List<decimal> Serie { get; private set; }

        public void AddItem(string label, decimal value)
        {
            Labels.Add(label);
            Serie.Add(value);
        }
    }
}
