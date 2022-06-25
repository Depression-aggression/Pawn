using Depra.Pawn.Runtime.Orientation.Types.Abstract;

namespace Depra.Pawn.Runtime.Orientation.Configuration.Interfaces
{
    public interface IOrientationConfiguration
    {
        OrientationType SetupOrientation(float initialYaw, float initialPitch);
    }
}