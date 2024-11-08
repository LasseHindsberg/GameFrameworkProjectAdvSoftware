using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Models.Creatures
{
    /// <summary>
    /// DefendState class to handle the defend state of a creature mainly the ReceiveHit method
    /// </summary>
    public class DefendState : IState
    {
        /// <summary>
        /// Handles when the creature enters the defend state
        /// </summary>
        /// <param name="creature"></param>
        public void EnterState(Creature creature)
        {
            Logger.MyLogger.Instance.Log($"{creature.Name} is preparing to defend...");
        }
        /// <summary>
        /// handles the action of the defend state
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="damageTaken">how much damage is being taken, usually called as OpponentCreature.Hit</param>
        public void HandleAction(Creature creature, int? damageTaken)
        {
            Logger.MyLogger.Instance.Log($"{creature.Name} is defending and takes {damageTaken} damage.");
            creature.ReceiveHit(damageTaken ?? 0);
        }
        /// <summary>
        /// exits the defend state
        /// </summary>
        /// <param name="creature"></param>
        public void ExitState(Creature creature)
        {
            Logger.MyLogger.Instance.Log($"{creature.Name} has finished defending.");
        }
    }
}
