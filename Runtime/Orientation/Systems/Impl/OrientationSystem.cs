using System;
using Depra.Pawn.Runtime.Orientation.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Systems.Impl
{
    public class OrientationSystem : IOrientationSystem
    {
        private readonly ILocalRotationReceiver _receiver;
        private readonly OrientationType _orientation;

        public Quaternion OriginLocalRotation { get; private set; }
        
        public event Action<Quaternion> RotationChanged;

        public void Execute(float yaw, float pitch)
        {
            var horizontalRotation = _orientation.CalculateHorizontalRotation(yaw);
            var verticalRotation = _orientation.CalculateVerticalRotation(pitch);

            UpdateRotation(horizontalRotation, verticalRotation);
        }

        public OrientationSystem(IOrientationConfiguration configuration, Vector2 initialAngles, ILocalRotationReceiver receiver)
        {
            _orientation = configuration.SetupOrientation(initialAngles.x, initialAngles.y);
            _receiver = receiver;
        }
        
        private void UpdateRotation(Quaternion horizontalRotation, Quaternion verticalRotation)
        {
            _receiver.SetLocalRotation(horizontalRotation, verticalRotation);
            OriginLocalRotation = _receiver.LocalRotation;
            
            RotationChanged?.Invoke(OriginLocalRotation);
        }
    }
}