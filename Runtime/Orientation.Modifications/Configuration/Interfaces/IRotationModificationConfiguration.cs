using Depra.Pawn.Runtime.Modifications.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Interfaces
{
    public interface IRotationModificationConfiguration
    {
        IModificationsCollection<OrientationModification<Quaternion>> GetRotationModifications();
    }
}