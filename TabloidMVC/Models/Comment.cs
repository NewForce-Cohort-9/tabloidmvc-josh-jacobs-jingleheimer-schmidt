﻿namespace TabloidMVC.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserProfileId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Post? Post { get; set; }
        public UserProfile? Profile { get; set; }
        public string DisplayName { get; set; }
    }
}
