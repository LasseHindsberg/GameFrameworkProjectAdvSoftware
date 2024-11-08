using GameFrameworkProjectAdvSoftware.Models.Attack;
using GameFrameworkProjectAdvSoftware.Models.Creatures;
using GameFrameworkProjectAdvSoftware.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Factories
{
    /// <summary>
    /// A factory class to create creatures
    /// </summary>
    public class CreatureFactory
    {
        /// <summary>
        /// A factory method to create a creature and adds an observer to it
        /// </summary>
        /// <param name="name">Name of the creature EG: Goblin</param>
        /// <param name="hitPoints">HealthPoints of the creature EG: 50</param>
        /// <param name="attackItem">AttackItem of the creature if any</param>
        /// <param name="DefenseItem">DefenseItem of the creature if any</param>
        /// <returns>Finished creature</returns>
        public Creature CreateCreature(string name, int hitPoints, AttackItem AttackItem)
        {
            Logger.MyLogger.Instance.Log("Creating creature: " + name + ", hitpoints: " + hitPoints);
            
            Creature creature = new Creature 
            {
                Name = name,
                HitPoint = hitPoints,
                Attack = AttackItem,

            };
            creature.AddObserver(new DeathLogger());

            return creature;

        }
    }
}
