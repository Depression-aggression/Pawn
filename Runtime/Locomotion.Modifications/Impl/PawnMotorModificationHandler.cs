using Depra.Pawn.Runtime.Locomotion.Modifications.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.Modifications.Abstract;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Impl
{
    public class PawnMotorModificationHandler : MonoBehaviour, IPawnMotorModificationHandler
    {
        [SerializeField] private PawnMotor _motor;
        
        private IModificationsCollection<ILocomotionModification> _modifications;

        public IModificationsCollection<ILocomotionModification> Modifications =>
            _modifications ??= new ModificationsDictionary<ILocomotionModification>();

        private void OnEnable()
        {
            _motor.Updated += ApplyAllModifications;
        }

        private void OnDisable()
        {
            _motor.Updated -= ApplyAllModifications;
        }

        public void ApplyAllModifications(ILocomotionContext context)
        {
            using (var enumerator = Modifications.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var modification = enumerator.Current;
                    var modifiedVelocity = modification.Modify(context);
                    _motor.SetVelocity(modifiedVelocity);
                }
            }
        }

        public void SetActive(bool active) => gameObject.SetActive(active);

        private void Reset()
        {
            _motor = GetComponent<PawnMotor>();
        }
    }
}