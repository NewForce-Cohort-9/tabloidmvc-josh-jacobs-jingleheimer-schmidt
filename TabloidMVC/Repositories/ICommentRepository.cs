using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentsByPostId(int id);
        void CreateComment (Comment comment);
        void DeleteComment (int id);
        Comment GetCommentById(int id);
    }
}
