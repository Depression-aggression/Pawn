using Depra.Pawn.Runtime.Locomotion.Motor;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Configuration.Interfaces
{
    public interface ILocomotionConfiguration
    {
        void ConfigureLayer(ILocomotionLayer layer);
    }
}