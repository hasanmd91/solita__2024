namespace CityBike.Service.src.DTO
{

    public record StationReadDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public int Capacity { get; set; }
        public required string X { get; set; }
        public required string Y { get; set; }
    }

    public record StationCreateDTO
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public required int Capacity { get; set; }
        public required string X { get; set; }
        public required string Y { get; set; }
    }


    public record StationUpdateDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? Capacity { get; set; }
        public string? X { get; set; }
        public string? Y { get; set; }
    }
    public record StationMetricsDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public int Capacity { get; set; }
        public required string X { get; set; }
        public required string Y { get; set; }
        public int TotalDepartures { get; set; }
        public int TotalArrivals { get; set; }
        public int AverageDistance { get; set; }
        public int AverageDuration { get; set; }
        public required List<string> Top5popularDepartureStations { get; set; }
        public required List<string> Top5popularReturnStations { get; set; }
    }
}