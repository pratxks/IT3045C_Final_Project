using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Models
{
    //Pratik Chaudhari
    public class Food
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string favoriteBreakfast { get; set; }
        public string favoriteLunch { get; set; }
        public string favoriteDinner { get; set; }
    }
}
