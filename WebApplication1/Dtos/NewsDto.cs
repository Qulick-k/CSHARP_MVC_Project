namespace WebApplication1.Dtos
{
    public class NewsDto
    {
        public Guid NewsId { get; set; }
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string UpdateEmploeeName { get; set; }
        public int Click { get; set; }
        public bool Enable { get; set; }
    }
}
