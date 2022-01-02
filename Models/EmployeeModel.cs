using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCInterviewDemoProject.Models
{
    public class EmployeeModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string PhoneNo { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        [Display(Name="Upload Files")]
        public string photo { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}