using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BingoMoviesPro.Models
{
    public class UserSignUp
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "სიმბოლოების რაოდენობა უნდა აღემატებოდეს ექვსს.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "სიმბოლოების რაოდენობა უნდა აღემატებოდეს ექვსს.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ თქვენი პროფილის სურათის ლინკი.")]
        public string ProfileImage { get; set; }

        public virtual ApplicationUser ApplicationUsers { get; set; }
        public string ApplicationUserId { get; set; }
    }
}