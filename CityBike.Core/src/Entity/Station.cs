using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CityBike.Core.src.Entity
{
    public class Station
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public int Capacity { get; set; }
        public required string X { get; set; }
        public required string Y { get; set; }
        [JsonIgnore]
        public ICollection<Journey>? DepartureJourneys { get; set; }
        [JsonIgnore]
        public ICollection<Journey>? ReturnJourneys { get; set; }
    }
}