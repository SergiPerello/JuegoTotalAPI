using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoTotalApi.Models
{
    public class RoleGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Difficulty { get; set; }
        public string Game { get; set; }
        public int OwnerId { get; set; }
        public Player Owner { get; set; }
        public ICollection<Playing> Playing { get; set; }
    }
}
