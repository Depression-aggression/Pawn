using System.Runtime.CompilerServices;
using UnityEngine;

namespace Depra.Pawn.Runtime.UpdateMethod.Abstract
{
    public abstract class UpdatablePawnBehavior : MonoBehaviour
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void UpdateManual()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void UpdateFixed()
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void UpdateLate()
        {
        }
    }
}