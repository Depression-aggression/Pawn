using Depra.Pawn.Runtime.Locomotion.Configuration.Abstract;
using Depra.Pawn.Runtime.Locomotion.Configuration.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;
using Depra.Pawn.Runtime.Locomotion.Targets.Abstract;
using Depra.Pawn.Runtime.Locomotion.Targets.Impl;
using Depra.Pawn.Runtime.Locomotion.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Impl
{
    public class FirstPersonPawnMotor : SoloPawnMotor
    {
        [SerializeField] private Transform _origin;
        [SerializeField] private VelocityReceiver _target;
        [SerializeField] private LocomotionConfigurationScriptable _configuration;

        protected override ILocomotionConfiguration Configuration => _configuration;

        private void Awake()
        {
            Setup();
            _configuration.ConfigureLayerExtensions(this);
        }

        public override void UpdateManual()
        {
            OnUpdate(Time.deltaTime);
        }

        public override void UpdateFixed()
        {
            OnUpdatePhysics(Time.fixedDeltaTime);
        }

        protected override IVelocityReceiver SetupVelocityReceiver() => _target;
        
        protected override IDirectionTransformer SetupDirectionTransformer() =>
            new TransformDirectionTransformer(_origin);
    }
}