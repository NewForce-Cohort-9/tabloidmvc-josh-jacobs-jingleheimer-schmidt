using TabloidMVC.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;


//So basically I used DogGo as a reference and based my work of that. I added View 
// view models for the UserProfile and the UserProfileDetails. Here in this view 
//view model I added public that get and set from Userprofile and a list
//of all the profiles. If you look at UserProfileDetailsViewModel, there isn't
//much there because I wasn't quite sure what it needed. I'm
//guessing that we need view models to talk to the repositories and cs files. 
//Down further in the Views folder I added views for UserProfile and UserProfileDetails. 
//I'll have comments in those files talking about how I made them and what I set 
//them to. 



namespace TabloidMVC.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public UserProfile UserProfile { get; set; }

        public List<UserProfileViewModel> UserProfiles { get; set; }


    }
}
