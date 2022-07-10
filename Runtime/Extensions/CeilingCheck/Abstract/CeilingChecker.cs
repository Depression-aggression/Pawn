using UnityEngine;

namespace Depra.Pawn.Runtime.Extensions.CeilingCheck.Abstract
{
    public abstract class CeilingChecker : MonoBehaviour
    {
        public abstract bool CanStand { get; protected set; }

        public abstract void CheckCeil();
    }
}