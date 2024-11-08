using GameFrameworkProjectAdvSoftware.Models.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.World
{
    /// <summary>
    /// A class that handles the world of the game
    /// </summary>
    public class World
    {
        /// <summary>
        /// The maximum x value of the world
        /// </summary>
        public int MaxX { get; set; }
        /// <summary>
        /// The maximum y value of the world
        /// </summary>
        public int MaxY { get; set; }

        /// <summary>
        /// a list of world objects
        /// </summary>
        // world objects
        private List<WorldObject> _worldObjects;
        /// <summary>
        /// a list of creatures
        /// </summary>
        // world creatures
        private List<Creature> _creatures;

        /// <summary>
        /// a constructor for the world class
        /// </summary>
        /// <param name="maxX">max X value for the world</param>
        /// <param name="maxY">max Y value for the world</param>
        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();
        }

        public override string ToString()
        {
            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}}}";
        }
    }
}
