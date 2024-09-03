using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(IConfiguration config) : base(config) { }

        public List<Comment> GetCommentsByPostId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT c.PostId as PostId, c.id as CommentId, c.UserProfileId as UserProfileId, c.Subject as Subject, c.Content as Content, c.CreateDateTime as CreateDateTime, up.DisplayName as DisplayName, up.FirstName as FirstName, up.LastName as LastName, up.Email as Email, up.CreateDateTime as ProfileCreateDateTime, up.ImageLocation as ImageLocation, up.UserTypeId as UserTypeID FROM Comment c LEFT JOIN UserProfile up ON c.UserProfileId = up.Id WHERE c.PostId = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Comment> comments = new List<Comment>();
                    while (reader.Read())
                    {
                        comments.Add(new Comment()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("CommentId")),
                            PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                            UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                            Subject = reader.GetString(reader.GetOrdinal("Subject")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreatedDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                            DisplayName = reader.GetString(reader.GetOrdinal("DisplayName"))

                        });

                    }
                   reader.Close();
                   return comments;
                }
            }
        }

        public void CreateComment(Comment comment)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Comment (PostId, UserProfileId, Subject, Content, CreateDateTime) OUTPUT INSERTED.ID VALUES (@postId, @userProfileId, @subject, @content, @createDateTime)";

                    cmd.Parameters.AddWithValue("@postId", comment.PostId);
                    cmd.Parameters.AddWithValue("@userProfileId", comment.UserProfileId);
                    cmd.Parameters.AddWithValue("@subject", comment.Subject);
                    cmd.Parameters.AddWithValue("@content", comment.Content);
                    cmd.Parameters.AddWithValue("@createDateTime", comment.CreatedDateTime);

                    int id = (int)cmd.ExecuteScalar();
                    comment.Id = id;
                }
            }
        }

        public void DeleteComment(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Comment WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public Comment GetCommentById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Comment WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.Read())
                    {
                        Comment comment = new Comment
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                            UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                            Subject = reader.GetString(reader.GetOrdinal("Subject")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreatedDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime"))
                        };
                        reader.Close();
                        return comment;
                    }
                    reader.Close();
                    return null;
                }
            }
        }
    }
}
