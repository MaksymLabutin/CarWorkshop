namespace CarWorkshop.Core
{
    public class Company
    {
        public Company(string name, CarTrademarks carTrademarks)
        {
            Name = name;
            CarTrademarks = carTrademarks;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }

        public CarTrademarks CarTrademarks { get; set; }
    }

    public enum CarTrademarks
    {
        Other = 0,
        Mercedes = 1,
        Vw = 2,
        Bmw = 3 
    }
}