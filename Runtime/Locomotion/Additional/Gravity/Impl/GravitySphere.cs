using Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Impl
{
    public class GravitySphere : MonoBehaviour, IGravitySource
    {
        [SerializeField] private float _gravity = 9.81f;
        [SerializeField, Min(0f)] private float _outerRadius = 10f;
        [SerializeField, Min(0f)] private float _outerFalloffRadius = 15f;
        [SerializeField, Min(0f)] private float _innerRadius = 5f;
        [SerializeField, Min(0f)] private float _innerFalloffRadius = 1f;

        private float _outerFalloffFactor;
        private float _innerFalloffFactor;

        private void Awake()
        {
            OnValidate();
        }

        public Vector3 GetGravity(IGravityComponent gravityComponent)
        {
            var direction = transform.position - gravityComponent.Position;
            var distance = direction.magnitude;
            if (distance > _outerFalloffRadius || distance < _innerFalloffRadius)
            {
                return Vector3.zero;
            }

            var gravity = _gravity / distance;
            gravity = DecreaseGravityLinearlyAlongRadii(gravity, distance);
            var gravityForce = gravity * direction;

            return gravityForce;
        }

        private float DecreaseGravityLinearlyAlongRadii(float gravity, float distance)
        {
            if (distance > _outerRadius)
            {
                gravity *= 1f - (distance - _outerRadius) * _outerFalloffFactor;
            }
            else if (distance < _innerRadius)
            {
                gravity *= 1f - (_innerRadius - distance) * _innerFalloffFactor;
            }

            return gravity;
        }

        private void OnValidate()
        {
            _innerFalloffRadius = Mathf.Max(_innerFalloffRadius, 0f);
            _innerRadius = Mathf.Max(_innerRadius, _innerFalloffRadius);
            _outerRadius = Mathf.Max(_outerRadius, _innerRadius);
            _outerFalloffRadius = Mathf.Max(_outerFalloffRadius, _outerRadius);
            _outerFalloffFactor = 1f / (_outerFalloffRadius - _outerRadius);
        }
        
        private void OnDrawGizmos()
        {
            var position = transform.position;
            if (_innerFalloffRadius > 0f && _innerFalloffRadius < _innerRadius)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere(position, _innerFalloffRadius);
            }

            Gizmos.color = Color.yellow;
            if (_innerRadius > 0f && _innerRadius < _outerRadius)
            {
                Gizmos.DrawWireSphere(position, _innerRadius);
            }

            Gizmos.DrawWireSphere(position, _outerRadius);

            if (_outerFalloffRadius > _outerRadius)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere(position, _outerFalloffRadius);
            }
        }
    }
}