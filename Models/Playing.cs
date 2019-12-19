using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuegoTotalApi.Models
{
    public class Playing
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int RoleGameId { get; set; }
        public RoleGame RoleGame { get; set; }
    }
}
