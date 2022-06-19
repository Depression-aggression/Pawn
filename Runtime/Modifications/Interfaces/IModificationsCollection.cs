using System;
using System.Collections.Generic;

namespace Depra.Pawn.Runtime.Modifications.Interfaces
{
    public interface IModificationsCollection<TModification> where TModification : IPawnModification
    {
        void AddModification(TModification modification);

        void RemoveModification(Type modificationType);

        IEnumerator<TModification> GetEnumerator();
    }
}