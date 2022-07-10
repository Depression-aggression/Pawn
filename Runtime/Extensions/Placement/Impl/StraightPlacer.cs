using Depra.Pawn.Runtime.Extensions.Placement.Abstract;
using Depra.Pawn.Runtime.UpdateMethod.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Extensions.Placement.Impl
{
    public class StraightPlacer : BodyPlacer
    {
        [SerializeField] private PawnBrainBase _controller;

        public override void Place(Vector3 position, Quaternion rotation)
        {
            Place(position, rotation.x, rotation.y);
        }

        public void Place(Vector3 position, float rotationX, float rotationY)
        {
            SetPositionAndRotation(position, Quaternion.Euler(rotationX, rotationY, 0));
        }

        private void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            _controller.transform.SetPositionAndRotation(position, rotation);
        }
    }
}