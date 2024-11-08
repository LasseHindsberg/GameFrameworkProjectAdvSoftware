using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameworkProjectAdvSoftware.Observer
{
    /// <summary>
    /// an interface for the creature that adds observers
    /// </summary>
    public interface ICreatureSubject
    {
        void AddObserver(ICreatureObserver observer);
        void RemoveObserver(ICreatureObserver observer);
        void NotifyObservers();

    }
}
