using System.Collections.Generic;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Modifications.Types.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Types.Impl
{
    public class GravityScalingModification : IVelocityModification
    {
        private readonly GravityComponent _gravityComponent;
        private readonly ILocomotionStateComponent _stateComponent;
        private readonly IDictionary<LocomotionStateFlags, float> _gravityScaleMap;

        public Vector3 Modify(Vector3 velocity)
        {
            var rawState = _stateComponent.GetRawData();
            if (_gravityScaleMap.TryGetValue(rawState, out var scale))
            {
                velocity += _gravityComponent.GravityForce * scale;
            }

            return velocity;
        }

        public GravityScalingModification(GravityComponent gravityComponent, ILocomotionStateComponent stateComponent,
            IDictionary<LocomotionStateFlags, float> gravityScaleMap)
        {
            _gravityComponent = gravityComponent;
            _stateComponent = stateComponent;
            _gravityScaleMap = gravityScaleMap;
        }
    }
}