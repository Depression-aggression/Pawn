using UnityEngine;

namespace Depra.Pawn.Runtime.Components.CursorLock
{
    public class CursorLocker : MonoBehaviour
    {
        private void OnEnable()
        {
            LockCursor();
        }
        
        private static void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}