using System.Collections.Generic;
using Depra.Pawn.Runtime.Orientation.Modifications.Commands;
using Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.Systems;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Interfaces;
using Depra.Pawn.Runtime.Orientation.Rotor.Abstract;
using Depra.Pawn.Runtime.ReadInput.Abstract;
using UnityEngine;
using UnityEngine.Assertions;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Handler
{
    public class RotorModificationHandler : MonoBehaviour
    {
        [SerializeField] private PawnRotor _rotor;
        [SerializeField] private MotorInputReader _motorInputReader;
        [SerializeField] private OrientationModificationConfig _config;

        private Vector2 _locomotionInput;
        private HeadRotationModificationSystem _rotationModificationSystem;
        private HeadPositionModificationSystem _positionModificationSystem;

        private IList<IOrientationModification> _allModifications;

        private void Start()
        {
            Assert.IsNotNull(_rotor);
            Assert.IsNotNull(_config);
            Assert.IsNotNull(_motorInputReader);
            
            _config.Initialize(_rotor.OriginLocalPosition);
            _rotationModificationSystem = new HeadRotationModificationSystem(_rotor.Receiver, _config);
            _positionModificationSystem = new HeadPositionModificationSystem(_rotor.CameraOrigin, _config);

            var rotationModifications = _config.GetRotationModifications();
            var positionModifications = _config.GetPositionModifications();
            _allModifications = new List<IOrientationModification>(rotationModifications.Count);
            CombineModifications(rotationModifications.GetAll());
            CombineModifications(positionModifications.GetAll());
        }

        private void OnEnable()
        {
            _rotor.RotationChanged += OnRotationChanged;
        }

        private void OnDisable()
        {
            _rotor.RotationChanged -= OnRotationChanged;
        }

        private void LateUpdate()
        {
            HandleInput();
        }

        private void OnRotationChanged(Quaternion previousRotation)
        {
            _rotationModificationSystem.ApplyRotationModifications(previousRotation, Time.deltaTime);
            _positionModificationSystem.ApplyPositionModifications(_rotor.OriginLocalPosition, Time.deltaTime);
        }

        private void HandleInput()
        {
            _locomotionInput = new Vector2(_motorInputReader.Horizontal(), _motorInputReader.Vertical());
            PrepareModifications();
        }

        private void PrepareModifications()
        {
            if (_allModifications.Count == 0)
            {
                return;
            }
            
            var modificationCommand =
                new PrepareOrientationModificationsCommand(_locomotionInput, _allModifications);
            modificationCommand.Execute();
        }

        private void CombineModifications(IEnumerable<IOrientationModification> modifications)
        {
            foreach (var modification in modifications)
            {
                if (_allModifications.Contains(modification))
                {
                    continue;
                }
                
                _allModifications.Add(modification);
            }
        }
    }
}