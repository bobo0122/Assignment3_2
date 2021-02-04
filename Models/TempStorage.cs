using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_2.Models
{
    public class TempStorage
    {
        //create a new list 
        private static List<ApplicationResponse> applications = new List<ApplicationResponse>();
        public static IEnumerable<ApplicationResponse> Applications => applications;
        public static void AddApplication(ApplicationResponse application)
        {
            applications.Add(application);

        }
    }
}
