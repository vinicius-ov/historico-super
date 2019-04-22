using System;
namespace Todoer.Model
{
    public class DatedPrice
    {
        public DateTime Date { get; set; }
        public double Price { get; set; }

        public DatedPrice(DateTime date, double price)
        {
            Date = date;
            Price = price;
        }
    }
}
