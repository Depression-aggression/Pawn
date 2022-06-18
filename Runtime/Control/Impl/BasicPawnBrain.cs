using Depra.Pawn.Runtime.Control.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Control.Impl
{
    public class BasicPawnBrain : PawnBrain
    {
        [SerializeField] private PawnMotor _motor;

        public override void Stop()
        {
            _motor.StopImmediately();
        }
    }
}