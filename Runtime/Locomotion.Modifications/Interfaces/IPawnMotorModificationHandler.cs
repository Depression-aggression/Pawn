using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.Modifications.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Interfaces
{
    public interface IPawnMotorModificationHandler
    {
        IModificationsCollection<ILocomotionModification> Modifications { get; }

        void ApplyAllModifications(ILocomotionContext context);

        void SetActive(bool active);
    }
}