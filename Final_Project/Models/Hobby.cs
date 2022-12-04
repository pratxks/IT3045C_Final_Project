using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string hobby { get; set; }
        public string favoriteVideoGame { get; set; }
        public string favoriteBoardGame { get; set; }
    }
}
