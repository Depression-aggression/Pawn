using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Abstract
{
    public abstract class LocomotionStateProcessingSystem : ILocomotionSystem
    {
        protected ILocomotionStateComponent CurrentState { get; }
        
        public abstract void OnUpdate(float frameTime);

        protected LocomotionStateProcessingSystem(ILocomotionStateComponent initialState)
        {
            CurrentState = initialState;
        }
    }
}