using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Model
{
    public class Army
    {
        private List<Nlo> _nlo;

        public Army() => _nlo = new List<Nlo>();

        public Nlo GetFreeNlo()
        {
            foreach (var nlo in _nlo)
                if(!nlo.InFight)
                    return nlo;

            return null;
        }

        public void AddNewNlo(Nlo nlo)
        {
            if (_nlo.Contains(nlo))
                return;

            if (nlo.InArmy)
                return;

            _nlo.Add(nlo);
            nlo.Destroying += () => RemoveNlo(nlo);
            nlo.SetArmy();
        }

        public void RemoveNlo(Nlo nlo)
        {
            if (!_nlo.Contains(nlo))
                return;

            _nlo.Remove(nlo);
        }
    }
}
