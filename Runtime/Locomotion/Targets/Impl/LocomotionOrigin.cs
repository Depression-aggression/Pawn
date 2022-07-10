using Depra.Pawn.Runtime.Locomotion.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Impl
{
    internal class LocomotionOrigin : IPositionProvider
    {
        private readonly IPositionProvider _positionProvider;

        public Vector3 Position
        {
            get => _positionProvider.Position;
            set => _positionProvider.Position = value;
        }

        public LocomotionOrigin(IPositionProvider positionProvider)
        {
            _positionProvider = positionProvider;
        }
    }
}