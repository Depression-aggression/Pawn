using Depra.Pawn.Runtime.Control.Abstract;
using Depra.Pawn.Runtime.UpdateMethod.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Control.Impl
{
    public class BasicPawnBrain : PawnBrain
    {
        [SerializeField] private UpdatablePawnBehavior[] _behaviors;
        
        private void Awake()
        {
            Initialize(_behaviors);
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