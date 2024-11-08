using GameFrameworkProjectAdvSoftware.Configurator;
using GameFrameworkProjectAdvSoftware.Factories;
using GameFrameworkProjectAdvSoftware.Logger;
using GameFrameworkProjectAdvSoftware.Models.Attack;
using GameFrameworkProjectAdvSoftware.Models.Creatures;
using GameFrameworkProjectAdvSoftware.Models.Defense;

// declaring factories (WorldObjectFactory and CreatureFactory) and logger 
var itemFactory = new WorldObjectFactory();
var creatureFactory = new CreatureFactory();
var logger = MyLogger.Instance;

logger.Log("initializing game");


// Initialize creatures
var attackAttributes1 = new Dictionary<string, int> { { "Damage", 15 }, { "Range", 3 } };
var sword = itemFactory.CreateWorldObject("AttackItem", "Sword", "Iron Greatsword", attackAttributes1);

var goblin = (sword is AttackItem swordItem)
    ? creatureFactory.CreateCreature("Goblin", 50, swordItem)
    : null;

// equip the goblin with defense items
var defenseAttributes1 = new Dictionary<string, int> { { "Armor", 2 } };
var shield = itemFactory.CreateWorldObject("DefenseItem", "Shield", "Iron Shield", defenseAttributes1);

var defenseAttributes2 = new Dictionary<string, int> { { "Armor", 4 } };
var helmet = itemFactory.CreateWorldObject("DefenseItem", "Helmet", "Iron Helmet", defenseAttributes2);

if (helmet is DefenseItem helmetItem)
{
    goblin.Loot(helmetItem);
}

if (shield is DefenseItem shieldItem)
{
    goblin.Loot(shieldItem);
}

var attackAttributes2 = new Dictionary<string, int> { { "Damage", 20 }, { "Range", 2 } };
var axe = itemFactory.CreateWorldObject("AttackItem", "Axe", "Iron Battleaxe", attackAttributes2);

var orc = (axe is AttackItem axeItem)
    ? creatureFactory.CreateCreature("Orc", 75, axeItem)
    : null;

if (goblin == null || orc == null)
{
    logger.Log("Failed to create creatures for the duel.");
    return;
}

var attackState = new AttackState();
var defendState = new DefendState();

// Fight loop
while (goblin.HitPoint > 0 && orc.HitPoint > 0)
{
    // Goblin attacks, Orc defends
    attackState.EnterState(goblin);
    int goblinDamage = goblin.Hit();
    attackState.HandleAction(goblin, goblinDamage);
    attackState.ExitState(goblin);

    defendState.EnterState(orc);
    defendState.HandleAction(orc, goblinDamage);
    defendState.ExitState(orc);

    if (orc.HitPoint <= 0)
    {
        logger.Log($"{orc.Name} has been defeated!");
        break;
    }

    // Orc attacks, Goblin defends
    attackState.EnterState(orc);
    int orcDamage = orc.Hit();
    attackState.HandleAction(orc, orcDamage);
    attackState.ExitState(orc);

    defendState.EnterState(goblin);
    defendState.HandleAction(goblin, orcDamage);
    defendState.ExitState(goblin);

    if (goblin.HitPoint <= 0)
    {
        logger.Log($"{goblin.Name} has been defeated!");
        break;
    }
}


Console.WriteLine("\n\n");
Console.WriteLine("-------------READING CONFIG FILE----------");
// example of using the config loader
var configLoader = new ConfigLoader();
logger.Log("Reading config file");
configLoader.ConfigRead("C:\\Users\\hurli\\Desktop\\School shit\\4th semester\\GameFrameworkProjectAdvSoftware\\GameFrameworkProjectAdvSoftware\\Configurator\\GameConfig.xml");