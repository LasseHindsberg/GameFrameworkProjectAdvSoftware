using GameFrameworkProjectAdvSoftware.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Models.Defense
{
    /// <summary>
    /// DefenseItem class to hold the defense items that a creature can equip
    /// </summary>
    public class DefenseItem : WorldObject
    {
        /// <summary>
        /// a property to hold the name of the defense item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// a property to hold the armor value of the defense item
        /// </summary>
        public int Armor { get; set; }
        /// <summary>
        /// a property to hold the type of the defense item such as shield, helmet, etc.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// a constructor for the DefenseItem class
        /// </summary>
        public DefenseItem()
        {
            Name = string.Empty;
            Armor = 0;
            Type = string.Empty;
            Lootable = true;
            Removeable = true;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Armor)}={Armor}, {nameof(Type)}={Type}}}";
        }
    }
}
