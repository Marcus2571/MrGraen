using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrGraen
{
    internal class Player : IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        
    }
}
