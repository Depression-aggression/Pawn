using Depra.Pawn.Runtime.Orientation.Rotor.Interfaces;

namespace Depra.Pawn.Runtime.Orientation.Configuration.Interfaces
{
    public interface IOrientationLayerConfiguration
    {
        void ConfigureLayer(IOrientationLayer layer, float initialYaw, float initialPitch);
    }
}