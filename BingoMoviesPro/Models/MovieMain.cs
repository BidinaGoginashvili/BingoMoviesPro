using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BingoMoviesPro.Models
{
    public class MovieMain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ ფილმის დასახელება ინგლისურად.")]
        public string MovieTitleEng { get; set; }

        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ ფილმის დასახელება ქართულად.")]
        public string MovieTitleKa { get; set; }

        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ ფილმის გამოშვების თარიღი.")]
        public string ReleaseDate { get; set; }

       
        public string MovieLength { get; set; }

        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ ფილმის IMDB რეიტინგი.")]
        public double MovieImdb { get; set; }

        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ ფილმის სურათის(ლინკი).")]
        public string MovieImgpath { get; set; }

        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ ფილმის ვიდეოს(ლინკი).")]
        public string MovieVdpath { get; set; }

        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ ფილმის ბიუჯეტი.")]
        public double budget { get; set; }

        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ რეჟისორის სახელი.")]
        public string DirectorFullName { get; set; }

        [StringLength(int.MaxValue)]
        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ ფილმის დახასიათება.")]
        public string Description { get; set; }

        public MovieGenres MovieGenres { get; set; }
        public int GenreId { get; set; }
    }
}