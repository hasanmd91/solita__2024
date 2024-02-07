namespace CityBike.Core.src.Entity
{
    public class Journey
    {
        public int Id { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int DepartureStationId { get; set; }
        public required Station DepartureStation { get; set; }
        public int ReturnStationId { get; set; }
        public required Station ReturnStation { get; set; }
        public int CoveredDistance { get; set; }
        public int Duration { get; set; }
    }
}
