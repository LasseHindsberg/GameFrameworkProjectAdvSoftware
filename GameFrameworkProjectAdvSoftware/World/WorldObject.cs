using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.World
{
    /// <summary>
    /// WorldObject class to hold the world objects that can be looted or removed
    /// </summary>
    public class WorldObject
    {
        /// <summary>
        /// a name for the world object
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// a property to determine if the world object is lootable
        /// </summary>
        public bool Lootable { get; set; }
        /// <summary>
        /// a property to determine if the world object is removeable
        /// </summary>
        public bool Removeable { get; set; }

        /// <summary>
        /// a constructor for the WorldObject class
        /// </summary>
        public WorldObject()
        {
            Name = string.Empty;
            Lootable = false;
            Removeable = false;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Lootable)}={Lootable.ToString()}, {nameof(Removeable)}={Removeable.ToString()}}}";
        }
    }
}
