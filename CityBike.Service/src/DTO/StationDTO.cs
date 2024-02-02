namespace CityBike.Service.src.DTO
{

    public record StationReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Capacity { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
    }


    public record StationCreateDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Capacity { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
    }


    public record StationUpdateDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Capacity { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
    }

}