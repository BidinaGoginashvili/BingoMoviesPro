using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BingoMoviesPro.Models
{
    public class MovieComments
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "გთხოვთ, შეავსოთ ველი კომენტარის დასაწერად.")]
        public string Comment{ get; set; }


        public MovieMain MovieMain { get; set; }
        public int MovieMainId { get; set; }

        public int ApplicationUserId { get; set; }
    }
}