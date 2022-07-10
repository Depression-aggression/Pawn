using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Targets.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Interfaces
{
    public interface ILocomotionLayer
    {
        IDirectionTransformer DirectionTransformer { get; }
        
        IVelocityReceiver[] VelocityReceivers { get; }
        
        void Setup();
        
        void OnUpdate(float frameTime);

        void OnUpdatePhysics(float frameTime);

        void AddSystem(ILocomotionSystem system);

        void AddPhysicsSystem(ILocomotionSystem system);
    }
}