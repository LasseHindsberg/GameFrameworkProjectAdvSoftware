using GameFrameworkProjectAdvSoftware.Logger;
using GameFrameworkProjectAdvSoftware.Models.Attack;
using GameFrameworkProjectAdvSoftware.Models.Defense;
using GameFrameworkProjectAdvSoftware.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Factories
{
    /// <summary>
    /// A factory class to create world objects, contains a switch statement to create different types of world objects
    /// </summary>
    public class WorldObjectFactory : IWorldObjectFactory
    {
        public WorldObject CreateWorldObject(string item, string itemType, string name, Dictionary<string, int> attributes)
        {
            switch (item)
            {
                case "AttackItem":
                    MyLogger.Instance.Log($"Creating AttackItem: {name}");
                    return new AttackItem
                    {
                        Name = name,
                        Type = itemType,
                        Damage = attributes.GetValueOrDefault("Damage", 0),
                        Range = attributes.GetValueOrDefault("Range", 0),
                        Lootable = true,
                        Removeable = true
                    };

                case "DefenseItem":
                    MyLogger.Instance.Log($"Creating DefenseItem: {name}");
                    return new DefenseItem
                    {
                        Name = name,
                        Type = itemType,
                        Armor = attributes.GetValueOrDefault("Armor", 0),
                        Lootable = true,
                        Removeable = true
                    };

                case "worldObject":
                    MyLogger.Instance.Log($"Creating WorldObject: {name}");
                    return new WorldObject
                    {
                        Name = name,
                        Lootable = true,
                        Removeable = true
                    };

                default:
                    throw new ArgumentException($"Unknown WorldObject type: {item}");
            }
        }
    }
}
