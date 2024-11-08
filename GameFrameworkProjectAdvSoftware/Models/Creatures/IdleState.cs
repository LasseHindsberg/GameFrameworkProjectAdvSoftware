using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Models.Creatures
{
    /// <summary>
    /// Handles the idle state of a creature aswell as looting and walking around the map
    /// </summary>
    public class IdleState : IState
    {
        /// <summary>
        /// Handles when the creature enters the idle state
        /// </summary>
        /// <param name="creature"></param>
        public void EnterState(Creature creature)
        {
            Console.WriteLine($"{creature.Name} has entered its idle state.");
        }
        // unsure what to add to be able for the creature to loot in the idle state, 
        /// <summary>
        /// handles the action of the idle state, wish to implement looting aswell as moving around the map
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="NuLL"></param>
        public void HandleAction(Creature creature, int? NuLL)
        {
            // walking around the map ? how to implement
            Console.WriteLine($"{creature.Name} is moving.");
        }
        /// <summary>
        /// handles when the creature exits the idle state
        /// </summary>
        /// <param name="creature"></param>
        /// <exception cref="NotImplementedException">throws a not implemented function</exception>
        public void ExitState(Creature creature)
        {
            throw new NotImplementedException();
        }
    }
}
