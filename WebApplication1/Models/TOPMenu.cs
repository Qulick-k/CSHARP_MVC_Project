namespace WebApplication1.Models
{
    public partial class TOPMenu
    {
        public Guid TOPMenuId { get; set; }

        public string Name { get; set; } = null!;

        public string Url { get; set; } = null!;

        public string Icon { get; set; } = null!;

        public int Orders { get; set; } = 0;
    }
}
