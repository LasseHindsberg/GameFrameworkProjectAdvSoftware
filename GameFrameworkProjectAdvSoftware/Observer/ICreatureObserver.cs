using GameFrameworkProjectAdvSoftware.Models.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Observer
{
    /// <summary>
    /// An interface to handle the death of a creature
    /// </summary>
    public interface ICreatureObserver
    {
        void OnCreatureDeath(Creature creature);
    }
}
