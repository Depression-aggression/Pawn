using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Systems.Abstract;
using Depra.Pawn.Runtime.Locomotion.Targets.Interfaces;
using Depra.Pawn.Runtime.ReadInput.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Impl
{
    public class PlayerLocomotionInputSystem : LocomotionInputSystem
    {
        private readonly IDirectionTransformer _directionTransformer;

        protected override void HandleDirectionInput(LocomotionInputComponent inputComponent,
            ILocomotionInputReader inputReader)
        {
            var rawDirection = new Vector3(inputReader.Horizontal(), 0f, inputReader.Vertical());
            rawDirection = Vector3.ClampMagnitude(rawDirection, 1f);
            
            var transformedDirection = _directionTransformer.WorldToLocalDirection(rawDirection);

            inputComponent.RawDirection = rawDirection;
            inputComponent.TransformedDirection = transformedDirection;
        }

        public PlayerLocomotionInputSystem(LocomotionInputComponent inputComponent, ILocomotionInputReader inputReader,
            IDirectionTransformer directionTransformer) : base(inputComponent, inputReader)
        {
            _directionTransformer = directionTransformer;
        }
    }
}