using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Interfaces;

namespace Depra.Pawn.Runtime.Modifications.Abstract
{
    public class ModificationsDictionary<TModification> : IModificationsCollection<TModification>
        where TModification : IPawnModification
    {
        private readonly IDictionary<Type, TModification> _modifications;

        public void AddModification(TModification modification)
        {
            var modificationType = modification.GetType();
            if (_modifications.ContainsKey(modificationType) == false)
            {
                _modifications[modificationType] = modification;
            }
        }

        public void RemoveModification(Type modificationType)
        {
            if (_modifications.ContainsKey(modificationType))
            {
                _modifications.Remove(modificationType);
            }
        }

        public IEnumerator<TModification> GetEnumerator()
        {
            return _modifications.Values.GetEnumerator();
        }

        public ModificationsDictionary()
        {
            _modifications = new Dictionary<Type, TModification>();
        }

        public ModificationsDictionary(IDictionary<Type, TModification> modifications)
        {
            _modifications = modifications;
        }
    }
}