using Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Impl
{
    public class GravityPlane : MonoBehaviour, IGravitySource
    {
        [SerializeField] private float _gravity = 9.81f;
        [SerializeField, Min(0f)] private float _range = 1f;

        private Vector3 GravityDirection => -transform.up;

        public Vector3 GetGravity(IGravityComponent gravityComponent)
        {
            var distance = Vector3.Dot(GravityDirection, gravityComponent.Position - transform.position);
            if (distance > _range)
            {
                // Strip gravity.
                return Vector3.zero;
            }

            var gravity = LinearDecreaseGravityByDistance(_gravity, distance);
            var gravityForce = gravity * GravityDirection;
            
            return gravityForce;
        }

        private float LinearDecreaseGravityByDistance(float gravity, float distance)
        {
            if (distance > 0f)
            {
                gravity *= 1f - distance / _range;
            }

            return gravity;
        }

        private void OnDrawGizmos()
        {
            Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(1f, 0f, 1f));

            var scale = transform.localScale;
            scale.y = _range;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, scale);

            if (_range == 0f)
            {
                return;
            }

            var size = new Vector3(1f, 0f, 1f);

            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(Vector3.up, size);
        }
    }
}