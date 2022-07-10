using Depra.Pawn.Runtime.Locomotion.Targets.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Abstract
{
    public abstract class SoloPawnMotor : PawnMotorBase
    {
        protected abstract IVelocityReceiver SetupVelocityReceiver();
        
        protected override IVelocityReceiver[] SetupVelocityReceivers()
        {
            return new[] { SetupVelocityReceiver() };
        }
    }
}