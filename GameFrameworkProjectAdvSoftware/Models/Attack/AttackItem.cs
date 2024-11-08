using GameFrameworkProjectAdvSoftware.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Models.Attack
{
    /// <summary>
    /// AttackItem class to hold the attack items that a creature can equip
    /// </summary>
    public class AttackItem : WorldObject
    {
        /// <summary>
        /// Name of the creature
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Damage of the attack item
        /// </summary>
        public int Damage { get; set; }
        /// <summary>
        /// Range of the attack item
        /// </summary>
        public int Range { get; set; }
        /// <summary>
        /// Type of the attack item, such as sword, bow, etc.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A constructor for the AttackItem class
        /// </summary>
        public AttackItem()
        {
            Name = string.Empty;
            Damage = 0;
            Range = 0;
            Type = string.Empty;
            Lootable = true;
            Removeable = true;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Type)}={Type}, {nameof(Damage)}={Damage.ToString()}, {nameof(Range)}={Range.ToString()}}}";
        }
    }
}
