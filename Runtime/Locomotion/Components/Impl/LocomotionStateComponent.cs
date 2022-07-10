using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Components.Impl
{
    public class LocomotionStateComponent : ILocomotionStateComponent
    {
        private LocomotionStateFlags _flags;

        public bool Grounded
        {
            get => _flags.HasFlag(LocomotionStateFlags.Grounded);
            set => SetFlag(LocomotionStateFlags.Grounded, value);
        }

        public bool Jumped
        {
            get => _flags.HasFlag(LocomotionStateFlags.Jumped);
            set => SetFlag(LocomotionStateFlags.Jumped, value);
        }

        public LocomotionStateFlags GetRawData() => _flags;

        public LocomotionStateComponent()
        {
            Grounded = true;
            Jumped = false;
        }
        
        private void SetFlag(LocomotionStateFlags targetFlag, bool value)
        {
            if (value)
            {
                _flags |= targetFlag;
            }
            else
            {
                _flags &= ~targetFlag;
            }
        }
    }
}