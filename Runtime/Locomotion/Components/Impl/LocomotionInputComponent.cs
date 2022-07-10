using System;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Components.Impl
{
    [Serializable]
    public class LocomotionInputComponent : ILocomotionInputComponent
    {
        [field: SerializeField] public Vector3 RawDirection { get; set; }
        [field: SerializeField] public Vector3 TransformedDirection { get; set; }

        private LocomotionInputFlags _flags;

        public LocomotionInputFlags GetRawData() => _flags;

        public LocomotionInputComponent()
        {
        }

        public LocomotionInputComponent(Vector3 rawDirection, Vector3 transformedDirection,
            LocomotionInputFlags flags = default)
        {
            _flags = flags;
            RawDirection = rawDirection;
            TransformedDirection = transformedDirection;
        }

        public LocomotionInputComponent(ILocomotionInputComponent data) : this(data.RawDirection,
            data.TransformedDirection,
            data.GetRawData())
        {
        }

        internal void OnJumpInputChanged(bool pressed)
        {
            _flags = ToggleFlag(_flags, LocomotionInputFlags.JumpHeld, pressed);
        }

        internal void OnWalkInputChanged(bool pressed)
        {
            _flags = ToggleFlag(_flags, LocomotionInputFlags.WalkHeld, pressed);
        }

        internal void OnSprintInputChanged(bool pressed)
        {
            _flags = ToggleFlag(_flags, LocomotionInputFlags.SprintHeld, pressed);
        }

        internal void OnCrouchPressed(bool pressed)
        {
            _flags = ToggleFlag(_flags, LocomotionInputFlags.CrouchHeld, pressed);
        }

        private static LocomotionInputFlags ToggleFlag(LocomotionInputFlags currentFlag,
            LocomotionInputFlags targetFlag, bool active)
        {
            if (active)
            {
                currentFlag |= targetFlag;
            }
            else
            {
                currentFlag &= ~targetFlag;
            }

            return currentFlag;
        }

        public override string ToString()
        {
            return $"Raw: {RawDirection}; Transformed {TransformedDirection}";
        }
    }
}