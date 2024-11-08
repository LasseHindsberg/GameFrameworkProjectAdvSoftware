using GameFrameworkProjectAdvSoftware.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Factories
{
    /// <summary>
    /// an interface for creating world objects
    /// </summary>
    public interface IWorldObjectFactory
    {
        WorldObject CreateWorldObject(string item, string itemType, string name, Dictionary<String, int> attributes);
    }
}
