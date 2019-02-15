using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BingoMoviesPro.Models
{
    public class Slider
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ სლაიდერის სურათის ლინკი.")]
        public string imgSlider { get; set; }
        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ სლაიდერის ლინკი.")]
        public string linkSlider { get; set; }
        [Required(ErrorMessage = "გთხოვთ, შეიყვანოთ სლაიდერის ტექსტი.")]
        public string textSlider { get; set; }
    }
}