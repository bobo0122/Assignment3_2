using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_2.Models.ViewModels
{
    public class MovieViewModel
    {
        public IQueryable<ApplicationResponse> ApplicationResponses { get; set; }
     
    }
}
