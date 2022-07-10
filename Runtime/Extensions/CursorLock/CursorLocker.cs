using UnityEngine;

namespace Depra.Pawn.Runtime.Extensions.CursorLock
{
    public class CursorLocker : MonoBehaviour
    {
        private void OnEnable()
        {
            HandleCursorLock(true);
        }
        
        private static void HandleCursorLock(bool lockState)
        {
            Cursor.lockState = lockState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}