using Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Impl
{
    public class GravityBox : MonoBehaviour, IGravitySource
    {
        [SerializeField] private float _gravity = 9.81f;
        [SerializeField] private Vector3 _boundaryDistance = Vector3.one;
        [SerializeField, Min(0f)] public float _innerDistance;
        [SerializeField, Min(0f)] private float _innerFalloffDistance;
        [SerializeField, Min(0f)] private float _outerDistance;
        [SerializeField, Min(0f)] private float _outerFalloffDistance;

        private float _innerFalloffFactor;
        private float _outerFalloffFactor;

        private void Awake()
        {
            OnValidate();
        }

        public Vector3 GetGravity(IGravityComponent gravityComponent)
        {
            var position = transform.InverseTransformDirection(gravityComponent.Position - transform.position);
            var gravityDirection = Vector3.zero;

            var outside = 0;
            if (position.x > _boundaryDistance.x)
            {
                gravityDirection.x = _boundaryDistance.x - position.x;
                outside = 1;
            }
            else if (position.x < -_boundaryDistance.x)
            {
                gravityDirection.x = -_boundaryDistance.x - position.x;
                outside = 1;
            }

            if (position.y > _boundaryDistance.y)
            {
                gravityDirection.y = _boundaryDistance.y - position.y;
                outside += 1;
            }
            else if (position.y < -_boundaryDistance.y)
            {
                gravityDirection.y = -_boundaryDistance.y - position.y;
                outside += 1;
            }

            if (position.z > _boundaryDistance.z)
            {
                gravityDirection.z = _boundaryDistance.z - position.z;
                outside += 1;
            }
            else if (position.z < -_boundaryDistance.z)
            {
                gravityDirection.z = -_boundaryDistance.z - position.z;
                outside += 1;
            }

            if (outside > 0)
            {
                var distance = outside == 1
                    ? Mathf.Abs(gravityDirection.x + gravityDirection.y + gravityDirection.z)
                    : gravityDirection.magnitude;
                
                if (distance > _outerFalloffDistance)
                {
                    return Vector3.zero;
                }

                var gravity = _gravity / distance;
                if (distance > _outerDistance)
                {
                    gravity *= 1f - (distance - _outerDistance) * _outerFalloffFactor;
                }

                return transform.TransformDirection(gravity * gravityDirection);
            }
            
            var distances = GetBoundaryDistances(position);

            if (distances.x < distances.y)
            {
                if (distances.x < distances.z)
                {
                    gravityDirection.x = GetGravityComponent(position.x, distances.x);
                }
                else
                {
                    gravityDirection.z = GetGravityComponent(position.z, distances.z);
                }
            }
            else if (distances.y < distances.z)
            {
                gravityDirection.y = GetGravityComponent(position.y, distances.y);
            }
            else
            {
                gravityDirection.z = GetGravityComponent(position.z, distances.z);
            }

            return transform.TransformDirection(gravityDirection);
        }

        private float GetGravityComponent(float coordinate, float distance)
        {
            if (distance > _innerFalloffDistance)
            {
                return 0f;
            }

            var gravity = _gravity;
            if (distance > _innerDistance)
            {
                gravity *= 1f - (distance - _innerDistance) * _innerFalloffFactor;
            }

            return coordinate > 0f ? -gravity : gravity;
        }

        private Vector3 GetBoundaryDistances(Vector3 position)
        {
            var distances = new Vector3()
            {
                x = _boundaryDistance.x - Mathf.Abs(position.x),
                y = _boundaryDistance.y - Mathf.Abs(position.y),
                z = _boundaryDistance.z - Mathf.Abs(position.z)
            };

            return distances;
        }

        private void OnValidate()
        {
            _boundaryDistance = Vector3.Max(_boundaryDistance, Vector3.zero);
            var maxInnerDistance = Mathf.Min(Mathf.Min(_boundaryDistance.x, _boundaryDistance.y), _boundaryDistance.z);
            _innerDistance = Mathf.Min(_innerDistance, maxInnerDistance);

            _innerFalloffDistance = Mathf.Max(Mathf.Min(_innerFalloffDistance, maxInnerDistance), _innerDistance);
            _outerFalloffDistance = Mathf.Max(_outerFalloffDistance, _outerDistance);

            _innerFalloffFactor = 1f / (_innerFalloffDistance - _innerDistance);
            _outerFalloffFactor = 1f / (_outerFalloffDistance - _outerDistance);
        }

        private void OnDrawGizmos()
        {
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);

            Vector3 size;
            if (_innerFalloffDistance > _innerDistance)
            {
                Gizmos.color = Color.cyan;
                size.x = 2f * (_boundaryDistance.x - _innerFalloffDistance);
                size.y = 2f * (_boundaryDistance.y - _innerFalloffDistance);
                size.z = 2f * (_boundaryDistance.z - _innerFalloffDistance);
                Gizmos.DrawWireCube(Vector3.zero, size);
            }

            if (_innerDistance > 0f)
            {
                Gizmos.color = Color.yellow;
                size.x = 2f * (_boundaryDistance.x - _innerDistance);
                size.y = 2f * (_boundaryDistance.y - _innerDistance);
                size.z = 2f * (_boundaryDistance.z - _innerDistance);
                Gizmos.DrawWireCube(Vector3.zero, size);
            }

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(Vector3.zero, 2f * _boundaryDistance);

            if (_outerDistance > 0f)
            {
                Gizmos.color = Color.yellow;
                DrawGizmosOuterCube(_outerDistance);
            }

            if (_outerFalloffDistance > _outerDistance)
            {
                Gizmos.color = Color.cyan;
                DrawGizmosOuterCube(_outerFalloffDistance);
            }
        }

        private void DrawGizmosOuterCube(float distance)
        {
            Vector3 a, b, c, d;
            a.y = b.y = _boundaryDistance.y;
            d.y = c.y = -_boundaryDistance.y;
            b.z = c.z = _boundaryDistance.z;
            d.z = a.z = -_boundaryDistance.z;
            a.x = b.x = c.x = d.x = _boundaryDistance.x + distance;
            DrawGizmosRect(a, b, c, d);
            a.x = b.x = c.x = d.x = -a.x;
            DrawGizmosRect(a, b, c, d);

            a.x = d.x = _boundaryDistance.x;
            b.x = c.x = -_boundaryDistance.x;
            a.z = b.z = _boundaryDistance.z;
            c.z = d.z = -_boundaryDistance.z;
            a.y = b.y = c.y = d.y = _boundaryDistance.y + distance;
            DrawGizmosRect(a, b, c, d);
            a.y = b.y = c.y = d.y = -a.y;
            DrawGizmosRect(a, b, c, d);

            a.x = d.x = _boundaryDistance.x;
            b.x = c.x = -_boundaryDistance.x;
            a.y = b.y = _boundaryDistance.y;
            c.y = d.y = -_boundaryDistance.y;
            a.z = b.z = c.z = d.z = _boundaryDistance.z + distance;
            DrawGizmosRect(a, b, c, d);
            a.z = b.z = c.z = d.z = -a.z;
            DrawGizmosRect(a, b, c, d);

            distance *= 0.5773502692f; // √(1/3)
            var size = _boundaryDistance;
            size.x = 2f * (size.x + distance);
            size.y = 2f * (size.y + distance);
            size.z = 2f * (size.z + distance);
            Gizmos.DrawWireCube(Vector3.zero, size);
        }

        private static void DrawGizmosRect(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            Gizmos.DrawLine(a, b);
            Gizmos.DrawLine(b, c);
            Gizmos.DrawLine(c, d);
            Gizmos.DrawLine(d, a);
        }
    }
}