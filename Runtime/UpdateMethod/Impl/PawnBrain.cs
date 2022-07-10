using Depra.Pawn.Runtime.UpdateMethod.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.UpdateMethod.Impl
{
    public class PawnBrain : PawnBrainBase
    {
        [SerializeField] private PawnBrainInitialization _initialization;

        private void Awake()
        {
            _initialization.InitializeBrain(this);
        }
        
        private void Update()
        {
            UpdateHandler.UpdateManual();
        }

        private void FixedUpdate()
        {
            UpdateHandler.UpdateFixed();
        }

        private void LateUpdate()
        {
            UpdateHandler.UpdateLate();
        }
    }
}