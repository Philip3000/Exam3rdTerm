namespace WaterFlowApiRest.Models
{
    public class WaterFlow
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Volume { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
