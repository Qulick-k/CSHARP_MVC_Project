namespace WebApplication1.Dtos
{
    public class NewsEditDto
    {
        public Guid NewsId { get; set; }
        public string Title { get; set; }        
        public string Content { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Boolean Enable { get; set; }

        //public DateTime UpdateDateTime { get; set; }

        //public DateTime InsertDateTime { get; set; }

    }
}
