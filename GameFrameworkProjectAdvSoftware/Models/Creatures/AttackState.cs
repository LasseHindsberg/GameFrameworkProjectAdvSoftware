using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Models.Creatures
{
    /// <summary>
    /// AttackState class to handle the attack state of a creature
    /// </summary>
    public class AttackState : IState
    {
        /// <summary>
        /// Handles when the creature enters the attack state
        /// </summary>
        /// <param name="creature">Which creature does the action</param>
        public void EnterState(Creature creature)
        {
            Logger.MyLogger.Instance.Log($"{creature.Name} is preparing to attack...");
        }

        /// <summary>
        /// Handles the action of the attack state
        /// </summary>
        /// <param name="creature">Which creature does the action</param>
        /// <param name="damage">How much damage is being dealt (is being auto handled from the creature class)</param>
        public void HandleAction(Creature creature, int? damage)
        {
            damage = creature.Hit();
            Logger.MyLogger.Instance.Log($"{creature.Name} attacks for {damage} damage!");
        }

        /// <summary>
        /// Handles when the creature exits the attack state
        /// </summary>
        /// <param name="creature">Which creature does the action</param>
        public void ExitState(Creature creature)
        {
            Logger.MyLogger.Instance.Log($"{creature.Name} has finished attacking...");
        }
    }
}
