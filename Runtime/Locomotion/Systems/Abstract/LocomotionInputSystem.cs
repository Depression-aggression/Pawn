using System.Collections.Generic;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;
using Depra.Pawn.Runtime.ReadInput.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Abstract
{
    public abstract class LocomotionInputSystem : ILocomotionSystem
    {
        private readonly IDictionary<LocomotionInputComponent, ILocomotionInputReader> _inputReadersMap;

        public void OnUpdate(float frameTime)
        {
            foreach (var (component, inputReader) in _inputReadersMap)
            {
                HandleDirectionInput(component, inputReader);
                HandleJumpInput(component, inputReader);
                HandleWalkInput(component, inputReader);
                HandleSprintInput(component, inputReader);
                HandleCrouchInput(component, inputReader);
            }
        }

        protected abstract void HandleDirectionInput(LocomotionInputComponent inputComponent,
            ILocomotionInputReader inputReader);

        protected LocomotionInputSystem(LocomotionInputComponent inputComponent, ILocomotionInputReader inputReader)
        {
            _inputReadersMap = new Dictionary<LocomotionInputComponent, ILocomotionInputReader>();
            _inputReadersMap.Add(inputComponent, inputReader);
        }

        private void HandleJumpInput(LocomotionInputComponent inputComponent, ILocomotionInputReader inputReader)
        {
            inputComponent.OnJumpInputChanged(inputReader.IsJumpPressed());
        }

        private void HandleSprintInput(LocomotionInputComponent inputComponent, ILocomotionInputReader inputReader)
        {
            inputComponent.OnSprintInputChanged(inputReader.IsSprintPressed());
        }

        private void HandleWalkInput(LocomotionInputComponent inputComponent, ILocomotionInputReader inputReader)
        {
            inputComponent.OnWalkInputChanged(inputReader.IsWalkPressed());
        }

        private void HandleCrouchInput(LocomotionInputComponent inputComponent, ILocomotionInputReader inputReader)
        {
            inputComponent.OnCrouchPressed(inputReader.IsCrouchPressed());
        }
    }
}