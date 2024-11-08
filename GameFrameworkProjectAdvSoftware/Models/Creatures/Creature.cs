using GameFrameworkProjectAdvSoftware.Models.Attack;
using GameFrameworkProjectAdvSoftware.Models.Defense;
using GameFrameworkProjectAdvSoftware.Observer;
using GameFrameworkProjectAdvSoftware.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameFrameworkProjectAdvSoftware.Models.Creatures
{
    /// <summary>
    /// A class to represent a creature in the game world 
    /// </summary>
    public class Creature : WorldObject, ICreatureSubject
    {
        /// <summary>
        /// a property to hold the name of the creature
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// a property to hold the hitpoints of the creature
        /// </summary>
        public int HitPoint { get; set; }
        /// <summary>
        /// a property to hold the current x position of the creature
        /// </summary>
        public int currentX { get; set; }
        /// <summary>
        /// a property to hold the current y position of the creature
        /// </summary>
        public int currentY { get; set; }

        /// <summary>
        /// a property to define the attack item of the creature
        /// </summary>
        public AttackItem? Attack { get; set; }

        /// <summary>
        /// a dictionary to hold the different defense items of the creature
        /// </summary>
        private Dictionary<string, DefenseItem> DefenseItems { get; set; }

        /// <summary>
        /// a state handler for the creature
        /// </summary>
        private IState _currentState;
        /// <summary>
        /// a list of observers for the creature
        /// </summary>
        private List<ICreatureObserver> observers = new List<ICreatureObserver>();


        /// <summary>
        /// a constructor for the creature class
        /// </summary>
        public Creature()
        {
            // starts the creature in the idleState by default
            _currentState = new IdleState();
            _currentState.EnterState(this);

            Name = string.Empty;
            HitPoint = 100;
            Attack = null;
            DefenseItems = new Dictionary<string, DefenseItem>();
            currentX = 0;
            currentY = 0;
        }

        /// <summary>
        /// a method to change the state of the creature
        /// </summary>
        /// <param name="newState">the new state that the creature will enter</param>
        public void setState(IState newState)
        {
            _currentState.ExitState(this);
            _currentState = newState;
            _currentState.EnterState(this);
        }
        /// <summary>
        /// a method to add an observer to the creature
        /// </summary>
        /// <param name="observer">desired observer from the interface</param>
        public void AddObserver(ICreatureObserver observer)
        {
            observers.Add(observer);
        }
        /// <summary>
        /// a method to remove an observer from the creature
        /// </summary>
        /// <param name="observer">desired observer from the interface</param>
        public void RemoveObserver(ICreatureObserver observer)
        {
            observers.Remove(observer);
        }
        /// <summary>
        /// a method to notify all observers of the creature, in this case the death of the creature
        /// </summary>
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.OnCreatureDeath(this);
            }
        }

        /// <summary>
        /// A method to attack another creature
        /// </summary>
        /// <returns>the ammount of damage the creature has total sum of attack items</returns>
        public int Hit()
        {
            // Calculate damage from equipped attack item
            return Attack?.Damage ?? 0;
        }
        /// <summary>
        /// A method to receive a hit from another creature and calculate the amount of damage taken after defense items are taken into account
        /// </summary>
        /// <param name="hit">initial damage taken</param>
        public virtual void ReceiveHit(int hit)
        {
            int totalDefense = DefenseItems.Values.Sum(defense => defense.Armor);
            int damageTaken = Math.Max(hit - totalDefense, 0);

            HitPoint = Math.Max(HitPoint - damageTaken, 0);

            Logger.MyLogger.Instance.Log($"{Name} received {damageTaken} damage. after {totalDefense} total Defense. \n{Name} has {HitPoint} HP remaining.");

            if (HitPoint <= 0)
            {
                Console.WriteLine($"{Name} has taken fatal damage and been eliminated.");
                NotifyObservers();
            }
        }
        /// <summary>
        /// Allows the creature to loot an object from the world depending on the type of object. different handling for attack and defense items
        /// </summary>
        /// <param name="obj">which object is being looted EG: Sword will be looted as an attackItem</param>
        public void Loot(WorldObject obj)
        {
            // needs to be able to loot attack and defense items from the worldobject depending on type
            // if attack item, set as attack item if none equipped
            // if defense item, add to dictionary of defense items
            if (obj is AttackItem attackItem)
            {
                if (Attack == null)
                {
                    Attack = attackItem;
                    Logger.MyLogger.Instance.Log($"{Name} looted {attackItem.Name}");
                }
            }

            else if (obj is DefenseItem defenseItem)
            {
                if (!DefenseItems.ContainsKey(defenseItem.Type))
                {
                    DefenseItems.Add(defenseItem.Type, defenseItem);
                    Logger.MyLogger.Instance.Log($"{Name} looted {defenseItem.Name}");
                }
                else
                {
                    Logger.MyLogger.Instance.Log($"{Name} already has a {defenseItem.Type} equipped.");
                }
            }

        }
        /// <summary>
        /// a method used in the handling of death of a creature
        /// </summary>
        /// <returns>the name of the creature specified</returns>
        public string GetName()
        {
            return Name;
        }



        public override string ToString()
        {
            var defenseItemsStr = string.Join(", ", DefenseItems.Values);
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint}, {nameof(Attack)}={Attack}, DefenseItems=[{defenseItemsStr}]}}";
        }
    }
}
