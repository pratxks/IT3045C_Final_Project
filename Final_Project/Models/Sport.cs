using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string favoriteSport { get; set; }
        public string favoriteTeam { get; set; }
        public string favoritePlayer { get; set; }
    }
}
