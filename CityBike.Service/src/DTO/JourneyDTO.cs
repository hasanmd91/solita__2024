using CityBike.Core.src.Entity;

namespace CityBike.Service.src.DTO
{
    public record JourneyReadDTO
    {
        public int Id { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int DepartureStationId { get; set; }
        public string DepartureStationName { get; set; }
        public int ReturnStationId { get; set; }
        public string ReturnStationName { get; set; }
        public int CoveredDistance { get; set; }
        public int Duration { get; set; }
    }

    public record JourneyCreateDTO
    {
        public DateTime DepartureDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int DepartureStationId { get; set; }
        public int ReturnStationId { get; set; }
        public int CoveredDistance { get; set; }
        public int Duration { get; set; }
    }
    public record JourneyUpdateDTO
    {
        public int Id { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int DepartureStationId { get; set; }
        public int ReturnStationId { get; set; }
        public int CoveredDistance { get; set; }
        public int Duration { get; set; }
    }

}