﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabloidMVC.Repositories;
using TabloidMVC.Models;
using TabloidMVC.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace TabloidMVC.Controllers
{
    public class CommentController : Controller
    {
       
        // GET: CommentController
        public ActionResult Index(int id)
        {
            Post post = _postRepository.GetPublishedPostById(id);
            int postId = post.Id;
            List<Comment> comments = _commentRepository.GetCommentsByPostId(postId);

            CommentIndexViewModel vm = new CommentIndexViewModel()
            {
                post = post,
                comments = comments
            };
            return View(vm);
        }

        // GET: CommentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommentController/Create
        public ActionResult Create(int id)
        {
            Comment comment = new Comment();
            comment.PostId = id;

            return View(comment);
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            try
            {
                comment.UserProfileId = GetCurrentUserProfileId();
                comment.CreatedDateTime = DateTime.Now;
               

                _commentRepository.CreateComment(comment);
                return RedirectToAction("Index", new {id = comment.PostId });
            }
            catch 
            {
                return View();
            }
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Delete/5
        public ActionResult Delete(int id)
        {
            Comment comment = _commentRepository.GetCommentById(id);
            return View(comment);
        }

        // POST: CommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Comment comment)
        {
            try
            {
                Comment CommentForPostId = _commentRepository.GetCommentById(id);
                int POSTID = CommentForPostId.PostId;
                _commentRepository.DeleteComment(id);
                return RedirectToAction("Index", new { id = POSTID });
            }
            catch
            {
                return View();
            }
        }

        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        public CommentController(ICommentRepository commentRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }
        private int GetCurrentUserProfileId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
