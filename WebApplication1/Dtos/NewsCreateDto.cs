namespace WebApplication1.Dtos
{
    public class NewsCreateDto
    {
        public string Title { get; set; }        
        public string Content { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        //public DateTime UpdateDateTime { get; set; }

        //public DateTime InsertDateTime { get; set; }

    }
}
