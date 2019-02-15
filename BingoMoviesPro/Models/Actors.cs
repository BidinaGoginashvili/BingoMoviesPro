using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BingoMoviesPro.Models
{
    public class Actors
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "გთხოვთ, შეავსოთ მოცემული ველი მსახიობის დასამატებლად.")]
        [StringLength(70, MinimumLength = 10,ErrorMessage = "სახელი უნდა შედგებოდეს მინიმუმ 10 სიმბოლოსგან.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "გთხოვთ, შეავსოთ მოცემული ველი მსახიობის სურათის დასამატებლად.")]
        public string ActorImg { get; set; }
    }
}