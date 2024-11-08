using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Models.Creatures
{
    /// <summary>
    /// An interface that handles the different states of the creature
    /// </summary>
    public interface IState
    {
        /// <summary>
        ///  Handles when the creature enters a state
        /// </summary>
        /// <param name="creature">whichever creature is being handled</param>
        void EnterState(Creature creature);

        /// <summary>
        /// Handles the action of the state
        /// </summary>
        /// <param name="creature">whichever creature is being handled</param>
        /// <param name="variable">Specific state variables EG: DamageTaken for the defendState</param>
        void HandleAction(Creature creature, int? variable);
        /// <summary>
        /// Resetting the creature to its default state
        /// </summary>
        /// <param name="creature">whichever creature is being handled</param>
        void ExitState(Creature creature);

    }
}
