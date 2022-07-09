using Depra.Pawn.Runtime.Orientation.Types.Abstract;

namespace Depra.Pawn.Runtime.Orientation.Configuration.Interfaces
{
    internal interface IOrientationTypeConfiguration
    {
        OrientationType ConfigureOrientationType(float initialYaw, float initialPitch);
    }
}