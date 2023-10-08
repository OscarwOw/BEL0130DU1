namespace BEL0130DU1
{
    public class AvgPrice
    {
        public double price { get; set; }
        public string Currency { get; set; }
        public override string ToString()
        {
            return $"{price} {Currency}";
        }
    }
}