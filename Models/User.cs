using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVC.Models
{
    public class User
    {
        public int? userID {get; set;}
        public string username { get; set;}
        public string password {get; set;}
    }
}