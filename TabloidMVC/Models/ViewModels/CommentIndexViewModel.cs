namespace TabloidMVC.Models.ViewModels
{
    public class CommentIndexViewModel
    {
        public Post post { get; set; }
        public List<Comment> comments { get; set; }
        public Comment? comment { get; set; }
    }
}
