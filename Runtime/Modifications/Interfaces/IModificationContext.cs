using System;

namespace Depra.Pawn.Runtime.Modifications.Interfaces
{
    public interface IModificationContext<in TModification> where TModification : IPawnModification
    {
        void AddModification(TModification modification);

        void RemoveModification(Type modificationType);
    }
}