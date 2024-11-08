using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameFrameworkProjectAdvSoftware.Configurator
{
    /// <summary>
    /// A class to read the configuration file for the game framework. XML file
    /// </summary>
    public class ConfigLoader
    {
        /// <summary>
        /// reads the configuration file
        /// </summary>
        /// <param name="filename">location of XML file is expected</param>
        public void ConfigRead(string filename)
        {
            XDocument configDoc;
            try
            {
                configDoc = XDocument.Load(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration file: {ex.Message}");
                return;
            }


            var world = configDoc.Descendants("World")
                .Select(w => new
                {
                    MaxX = (int?)w.Element("MaxX") ?? 0,
                    MaxY = (int?)w.Element("MaxY") ?? 0
                })
                .FirstOrDefault();
            // checks for null
            if (world != null)
            {
                Console.WriteLine($"World: MaxX={world.MaxX}, MaxY={world.MaxY}");
            }
            else
            {
                Console.WriteLine("No World node found in the configuration file");
            }


            var creatures = configDoc.Descendants("Creature")
                .Select(c => new
                {
                    Name = c.Element("Name")?.Value ?? "Unknown",
                    HitPoints = (int?)c.Element("HitPoint") ?? 0
                });

            Console.WriteLine("Creature configurations:");
            foreach (var creature in creatures)
            {
                Console.WriteLine($"Creature: Name={creature.Name}, HitPoints={creature.HitPoints}");
            }


            var attackItems = configDoc.Descendants("AttackItem")
                .Select(a => new
                {
                    Name = a.Element("Name")?.Value ?? "Unknown",
                    Damage = (int?)a.Element("Damage") ?? 0,
                    Range = (int?)a.Element("Range") ?? 0
                });

            Console.WriteLine("Attack items:");

            foreach (var attack in attackItems)
            {
                Console.WriteLine($"Attack: Name={attack.Name}, Damage={attack.Damage}, Range={attack.Range}");
            }

 
            var defenseItems = configDoc.Descendants("DefenseItem")
                .Select(d => new
                {
                    Name = d.Element("Name")?.Value ?? "Unknown",
                    DefenseValue = (int?)d.Element("Defense") ?? 0
                });

            Console.WriteLine("Defense items:");
            foreach (var defense in defenseItems)
            {
                Console.WriteLine($"Defense: Name={defense.Name}, Defense={defense.DefenseValue}");
            }
        }
    }
}
