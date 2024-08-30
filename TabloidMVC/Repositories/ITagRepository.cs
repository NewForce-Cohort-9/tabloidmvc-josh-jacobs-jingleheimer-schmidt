using System.Collections.Generic;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAll();
        void AddTag(Tag tag);
        public Tag GetTagById(int id);
        public void DeleteTag(int tagId);
    }
}
