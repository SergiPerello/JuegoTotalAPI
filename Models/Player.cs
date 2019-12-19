using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoTotalApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Alias { get; set; }
        public ICollection<Playing> Playing { get; set; }
        public ICollection<RoleGame> Owner { get; set; }
    }
}
