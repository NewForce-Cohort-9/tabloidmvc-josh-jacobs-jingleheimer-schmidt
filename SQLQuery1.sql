SELECT c.PostId as PostId, c.id as CommentId, c.UserProfileId as UserProfileId, c.Subject as Subject, c.Content as Content, c.CreateDateTime as CreateDateTime, up.DisplayName as DisplayName, up.FirstName as FirstName, up.LastName as LastName, up.Email as Email, up.CreateDateTime as ProfileCreateDateTime, up.ImageLocation as ImageLocation, up.UserTypeId as UserTypeID FROM Comment c LEFT JOIN UserProfile up ON c.UserProfileId = up.Id WHERE PostId =1

INSERT INTO Comment (PostId, UserProfileId, Subject, Content, CreateDateTime) VALUES ('1', '1', 'Great Article!', 'I love this article so much!', '2008-11-11 13:23:44')

SELECT * FROM Comment