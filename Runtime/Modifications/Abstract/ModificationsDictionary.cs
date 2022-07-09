using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Modifications.Interfaces;

namespace Depra.Pawn.Runtime.Modifications.Abstract
{
    public class ModificationsDictionary<TModification> : IModificationsCollection<TModification>
        where TModification : IPawnModification
    {
        private const int DefaultCapacity = 10;

        private readonly IDictionary<Type, TModification> _modifications;

        public int Count => _modifications.Count;

        public void AddModification(TModification modification)
        {
            if (modification == null)
            {
                throw new NullReferenceException("Modification is null!");
            }

            var modificationType = modification.GetType();
            if (_modifications.ContainsKey(modificationType) == false)
            {
                _modifications[modificationType] = modification;
            }
        }

        public void RemoveModification(Type modificationType)
        {
            if (modificationType == null)
            {
                throw new NullReferenceException("Modification type is null!");
            }

            if (_modifications.ContainsKey(modificationType))
            {
                _modifications.Remove(modificationType);
            }
        }

        public IEnumerable<TModification> GetAll() => _modifications.Values;

        public ModificationsDictionary() : this(DefaultCapacity)
        {
        }

        public ModificationsDictionary(int capacity)
        {
            _modifications = new Dictionary<Type, TModification>(capacity);
        }

        public ModificationsDictionary(IDictionary<Type, TModification> modifications)
        {
            _modifications = modifications ?? new Dictionary<Type, TModification>();
        }
    }
}