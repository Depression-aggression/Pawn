using System.Collections.Generic;
using Depra.Pawn.Runtime.Commands.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Commands
{
    public readonly struct PrepareOrientationModificationsCommand : IPawnCommand
    {
        private readonly Vector3 _motionDirection;
        private readonly IEnumerable<IOrientationModification> _modifications;

        public void Execute()
        {
            foreach (var modification in _modifications)
            {
                modification.SetDirection(_motionDirection);
            }
        }

        public void Undo()
        {
            foreach (var modification in _modifications)
            {
                modification.SetDirection(-_motionDirection);
            }
        }

        public PrepareOrientationModificationsCommand(Vector3 motionDirection, IEnumerable<IOrientationModification> modifications)
        {
            _modifications = modifications;
            _motionDirection = motionDirection;
        }
    }
}