namespace Models
{
    public class Tank
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int Volume { get; set; }
        public required int MaxVolume { get; set; }
        public required int UnitId { get; set; }
    }

}
