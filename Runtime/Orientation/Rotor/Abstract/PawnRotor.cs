using System;
using Depra.Pawn.Runtime.Orientation.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Rotor.Interfaces;
using Depra.Pawn.Runtime.Orientation.Systems.Impl;
using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using Depra.Pawn.Runtime.UpdateMethod.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Abstract
{
    public abstract class PawnRotor : UpdatablePawnBehavior, IOrientationContext
    {
        private IOrientationSystem _orientationSystem;

        public Vector3 OriginLocalPosition => CameraOrigin.localPosition;
        public Quaternion OriginLocalRotation => _orientationSystem.OriginLocalRotation;
        
        internal abstract Transform CameraOrigin { get; }
        internal abstract ILocalRotationReceiver Receiver { get; }
        
        protected abstract IOrientationConfiguration Configuration { get; }

        public event Action<Quaternion> RotationChanged;
        
        protected void Init(Quaternion initialRotation)
        {
            var initialAngles = new Vector2(initialRotation.x, initialRotation.y);
            _orientationSystem = new OrientationSystem(Configuration, initialAngles, Receiver);

            _orientationSystem.RotationChanged += RotationChanged;
        }

        protected void HandleInput(float yaw, float pitch)
        {
            _orientationSystem.Execute(yaw, pitch);
        }
        
        private void OnDestroy()
        {
            _orientationSystem.RotationChanged -= RotationChanged;
        }
    }
}