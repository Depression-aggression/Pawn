﻿using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class WalkingState : MotionState
    {
        public WalkingState(IPawnMotor motor, LocomotionType locomotionType) : base(motor, locomotionType)
        {
        }
    }
}