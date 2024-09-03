using System.Diagnostics.Contracts;

namespace TabloidMVC.Models.ViewModels
{
    public class CommentCreateViewModel
    {
        public Post post {  get; set; }
        public Comment comment { get; set; }
    }
}
