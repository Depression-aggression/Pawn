using System;
using Depra.Pawn.Runtime.Locomotion.Configuration.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Targets.Interfaces;
using Depra.Pawn.Runtime.UpdateMethod.Abstract;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Abstract
{
    public abstract class PawnMotorBase : UpdatablePawnBehavior, ILocomotionLayer
    {
        private ILocomotionSystem[] _systems;
        private ILocomotionSystem[] _physicsSystems;

        public IVelocityReceiver[] VelocityReceivers { get; private set; }
        public IDirectionTransformer DirectionTransformer { get; private set; }
        
        protected abstract ILocomotionConfiguration Configuration { get; }
        
        public void Setup()
        {
            _systems = Array.Empty<ILocomotionSystem>();
            _physicsSystems = Array.Empty<ILocomotionSystem>();
            
            VelocityReceivers = SetupVelocityReceivers();
            DirectionTransformer = SetupDirectionTransformer();
            
            Configuration.ConfigureLayer(this);
        }

        public void OnUpdate(float frameTime)
        {
            foreach (var system in _systems)
            {
                system.OnUpdate(frameTime);
            }
        }

        public void OnUpdatePhysics(float frameTime)
        {
            foreach (var system in _physicsSystems)
            {
                system.OnUpdate(frameTime);
            }
        }
        
        public void AddSystem(ILocomotionSystem system)
        {
            Array.Resize(ref _systems, _systems.Length + 1);
            _systems[^1] = system;
        }

        public void AddPhysicsSystem(ILocomotionSystem system)
        {
            Array.Resize(ref _physicsSystems, _physicsSystems.Length + 1);
            _physicsSystems[^1] = system;
        }

        protected abstract IVelocityReceiver[] SetupVelocityReceivers();
        
        protected abstract IDirectionTransformer SetupDirectionTransformer();
    }
}