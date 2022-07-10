using UnityEngine;

namespace Depra.Pawn.Runtime.Extensions.Placement.Abstract
{
    public abstract class BodyPlacer : MonoBehaviour
    {
        public abstract void Place(Vector3 position, Quaternion rotation);
    }
}