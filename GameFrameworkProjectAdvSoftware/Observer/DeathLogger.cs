using GameFrameworkProjectAdvSoftware.Models.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Observer
{
    /// <summary>
    ///  A class used to handle death logs of creatures
    /// </summary>
    public class DeathLogger : ICreatureObserver
    {
        /// <summary>
        /// A method to log the death of a creature
        /// </summary>
        /// <param name="creature">Dead Creature</param>
        public void OnCreatureDeath(Creature creature)
        {
            Console.WriteLine($"Logger: {creature.GetName()} is dead and removed from the game.");
            
        }
    }

}
