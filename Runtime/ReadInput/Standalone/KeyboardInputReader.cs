using System.Collections.Generic;
using System.Linq;
using Depra.Pawn.Runtime.Modules.ReadInput.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Modules.ReadInput.Standalone
{
    [CreateAssetMenu(fileName = "Keyboard Input", menuName = "Depra/Character/Input/Keyboard", order = 51)]
    public class KeyboardInputReader : MotorInputReader
    {
        [SerializeField] private KeyCode[] _leftKeys = { KeyCode.A };
        [SerializeField] private KeyCode[] _rightKeys = { KeyCode.D };
        [SerializeField] private KeyCode[] _forwardKeys = { KeyCode.W };
        [SerializeField] private KeyCode[] _backKeys = { KeyCode.S };
        [SerializeField] private KeyCode[] _jumpKeys = { KeyCode.Space };
        [SerializeField] private KeyCode[] _sprintKeys = { KeyCode.LeftShift };
        [SerializeField] private KeyCode[] _walkKeys = { KeyCode.LeftAlt };
        [SerializeField] private KeyCode[] _crouchKeys = { KeyCode.LeftControl };
        
        public override float Horizontal() => GetKeyAxis(_leftKeys, _rightKeys);

        public override float Vertical() => GetKeyAxis(_backKeys, _forwardKeys);

        public override bool IsJumpPressed() => GetKeyButton(_jumpKeys);

        public override bool IsSprintPressed() => GetKeyButton(_sprintKeys);

        public override bool IsWalkPressed() => GetKeyButton(_walkKeys);

        public override bool IsCrouchPressed() => GetKeyButton(_crouchKeys);
        
        private static float GetKeyAxis(IEnumerable<KeyCode> negative, IEnumerable<KeyCode> positive)
        {
            if (GetKeyButton(negative))
            {
                return -1f;
            }

            return GetKeyButton(positive) ? 1f : 0f;
        }

        private static bool GetKeyButton(IEnumerable<KeyCode> keyCodes)
        {
            return keyCodes.Any(Input.GetKey);
        }
    }
}