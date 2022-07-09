using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using Depra.Pawn.Runtime.Orientation.Targets.Abstract;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Interfaces
{
    public interface IOrientationLayer
    {
        OrientationOrigin[] Origins { get; }
        
        void Setup();
        
        void OnUpdate(float timeStep);

        void AddSystem(IOrientationSystem system);
    }
}