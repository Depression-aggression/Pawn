using Depra.Pawn.Runtime.Common;
using Depra.Pawn.Runtime.Modifications.Abstract;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.HeadTilt.Impl;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Impl;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadTilt.Impl;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Impl
{
    [CreateAssetMenu(fileName = "Orientation Modifications",
        menuName = Constants.FrameworkPath + Constants.ModulePath + "Orientation/Modifications/Basic", order = 52)]
    public class BasicOrientationModificationConfig : OrientationModificationConfig
    {
        [SerializeField] private HeadTiltSettings _headTiltSettings = new(3f, 5f, 10f);
        [SerializeField] private HeadBobSettings _headBobSettings = new(0.05f, 14f);

        private IModificationsCollection<OrientationModification<Quaternion>> _rotationModifications;
        private IModificationsCollection<OrientationModification<Vector3>> _positionModifications;
        
        public override IModificationsCollection<OrientationModification<Quaternion>> GetRotationModifications()
        {
            if (_rotationModifications != null)
            {
                return _rotationModifications;
            }
            
            _rotationModifications = new ModificationsDictionary<OrientationModification<Quaternion>>();

            var headTilt = new BasicHeadTilt(_headTiltSettings);
            var headTiltModification = new HeadTiltModification(headTilt);

            _rotationModifications.AddModification(headTiltModification);

            return _rotationModifications;
        }

        public override IModificationsCollection<OrientationModification<Vector3>> GetPositionModifications()
        {
            if (_positionModifications != null)
            {
                return _positionModifications;
            }
            
            _positionModifications = new ModificationsDictionary<OrientationModification<Vector3>>();

            var headBob = new BasicHeadBob(_headBobSettings, InitialOriginPosition.y);
            var headBobModification = new HeadBobModification(headBob);

            _positionModifications.AddModification(headBobModification);

            return _positionModifications;
        }
    }
}