using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{
    class Player
    {
        public string Name { get; set; }
        public Hand Hand { get; set; }
    
       public Player(string Name)
        {
            this.Name = Name;
        }
        
        // Returning the Name of the Player and the Hand they have entered
        public override string ToString()
        {
            return this.Name + " Has hand " + this.Hand;
        }
    }
}
