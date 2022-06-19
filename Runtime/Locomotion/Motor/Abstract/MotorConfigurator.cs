using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;
using Depra.Pawn.Runtime.StateMachine.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Abstract
{
    public abstract class MotorConfigurator : ScriptableObject
    {
        public abstract LocomotionType SetupMovement(float frameTime);

        public abstract IPawnStateMachine SetupMotor(PawnMotor motor, LocomotionType locomotionType);
    }
}