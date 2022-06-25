using Depra.Pawn.Runtime.Orientation.Rotor.Interfaces;

namespace Depra.Pawn.Runtime.Orientation.Systems.Interfaces
{
    public interface IOrientationSystem : IOrientationContext
    {
        void Execute(float yaw, float pitch);
    }
}