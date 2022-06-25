using System.Collections.Generic;

namespace Depra.Pawn.Runtime.Modifications.Interfaces
{
    public interface IModificationsCollection<TModification> : IModificationContext<TModification>
        where TModification : IPawnModification
    {
        int Count { get; }
        
        ICollection<TModification> GetAll();
    }
}