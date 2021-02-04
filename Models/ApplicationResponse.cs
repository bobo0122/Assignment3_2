using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_2.Models
{
    public class ApplicationResponse
    {

        [Required]
        public string Category { get; set; }

        //prop tab tab builds the following:
        [Required]
        public string Title { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string SelectRatingType { get; set; }
        public bool? Edited { get; set; }
        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}
