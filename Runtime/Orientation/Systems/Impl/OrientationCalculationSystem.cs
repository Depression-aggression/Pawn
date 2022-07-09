using Depra.Pawn.Runtime.Orientation.Actor.Impl;
using Depra.Pawn.Runtime.Orientation.Structs;
using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using Depra.Pawn.Runtime.ReadInput.Interfaces;

namespace Depra.Pawn.Runtime.Orientation.Systems.Impl
{
    public class OrientationCalculationSystem : IOrientationSystem
    {
        private readonly IOrientationInputReader _inputReader;
        private readonly OrientationComponent _orientationComponent;

        public void OnUpdate(float timeStep)
        {
            var yawInput = _inputReader.Yaw;
            var pitchInput = _inputReader.Pitch;

            var orientationType = _orientationComponent.OrientationType;
            
            var horizontalRotation = orientationType.CalculateHorizontalRotation(yawInput);
            var verticalRotation = orientationType.CalculateVerticalRotation(pitchInput);
            var biaxialRotation = new BiaxialRotation(horizontalRotation, verticalRotation);

            _orientationComponent.TargetLocalRotation = biaxialRotation;
        }

        public OrientationCalculationSystem(OrientationComponent orientationActor,
            IOrientationInputReader inputReader)
        {
            _inputReader = inputReader;
            _orientationComponent = orientationActor;
        }
    }
}