using System;
using System.Collections.Generic;
using System.Linq;
using ChefsNDishes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class DishController : Controller
    {
        private ChefDishContext db;
        public DishController(ChefDishContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
          return RedirectToAction("All");
        }

        // 1. handles GET request to DISPLAY the form used to create a new Post
        [HttpGet("/dish/new")]
        public IActionResult New()
        {
          List<Chef> allChefs = db.Chefs.ToList();
          ViewBag.allChefs = allChefs;
          return View("AddDish"); 
        }

        // 2. handles POST request form submission to CREATE a new Post model instance
        [HttpPost("/dishes/create")]
        public IActionResult CreateDish (Dish newDish)
        {
            // Every time a form is submitted, check the validations.
            if (ModelState.IsValid == false)
            { 
                // Go back to the form so error messages are displayed.
                return RedirectToAction("New");
            }
            // The above return did not happen so ModelState IS valid.
            db.Dishes.Add(newDish);
            // db doesn't update until we run save changes
            // after SaveChanges, our newPost object now has it's PostId updated from db auto generated id
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet("/dishes")]
        public IActionResult All()
        {
            List<Dish> allDishes = db.Dishes.ToList();
            return View("Dishes", allDishes);
        }

        [HttpGet("/dishes/{dishId}")]
        public IActionResult Details(int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(c => c.DishId == dishId);

            if (dish == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", dish);
        }

        [HttpPost("/dishes/{dishId}/delete")]
        public IActionResult Delete(int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(p => p.DishId == dishId);

            if (dish == null)
            {
                return RedirectToAction("All");
            }

            db.Dishes.Remove(dish);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet("/dishes/{dishId}/edit")]
        public IActionResult Edit(int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(p => p.DishId == dishId);

            if (dish == null)
            {
                return RedirectToAction("All");
            }

            return View("Edit", dish);
        }

        // [HttpPost("/posts/{postId}/update")]
        // public IActionResult Update(int postId, Post editedPost)
        // {
        //     if (ModelState.IsValid == false)
        //     {
        //         editedPost.PostId = postId;
        //         // Send back to the page with the current form edited data to
        //         // display errors.
        //         return View("Edit", editedPost);
        //     }

        //     Post dbPost = db.Posts.FirstOrDefault(p => p.PostId == postId);

        //     if (dbPost == null)
        //     {
        //         return RedirectToAction("All");
        //     }

        //     dbPost.Topic = editedPost.Topic;
        //     dbPost.Body = editedPost.Body;
        //     dbPost.ImgUrl = editedPost.ImgUrl;
        //     dbPost.UpdatedAt = DateTime.Now;

        //     db.Posts.Update(dbPost);
        //     db.SaveChanges();

        //     /* 
        //     When redirecting to action that has params, you need to pass in a
        //     dict with keys that match param names and the value of the keys are
        //     the values for the params.
        //     */
        //     return RedirectToAction("Details", new { postId = postId });
        // }
    }
}