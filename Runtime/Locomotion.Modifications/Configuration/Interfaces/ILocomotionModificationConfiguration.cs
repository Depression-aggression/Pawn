using Depra.Pawn.Runtime.Locomotion.Modifications.Types.Interfaces;
using Depra.Pawn.Runtime.Modifications.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Configuration.Interfaces
{
    public interface ILocomotionModificationConfiguration
    {
        IModificationsCollection<IVelocityModification> GetAllModifications();
    }
}