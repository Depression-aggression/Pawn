using System.Collections.Generic;
using Depra.Pawn.Runtime.Common;
using Depra.Pawn.Runtime.Modifications.Abstract;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Impl;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadTilt.Impl;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Impl
{
    [CreateAssetMenu(fileName = "Orientation Modifications",
        menuName = Constants.FrameworkPath + Constants.ModulePath + "Orientation/Modifications/Basic", order = 52)]
    public class BasicOrientationModificationConfigurationScriptable : OrientationModificationConfigurationScriptable
    {
        [SerializeField] private HeadTiltSettings _headTiltSettings = new(3f, 5f, 10f);
        [SerializeField] private HeadBobSettings _headBobSettings = new(1.7f, 0.05f, 14f);

        private IModificationsCollection<OrientationModification<Quaternion>> _rotationModifications;
        private IModificationsCollection<OrientationModification<Vector3>> _positionModifications;

        public override IModificationsCollection<OrientationModification<Quaternion>> GetRotationModifications()
        {
            if (_rotationModifications != null)
            {
                return _rotationModifications;
            }

            return _rotationModifications = FillRotationModifications();
        }

        public override IModificationsCollection<OrientationModification<Vector3>> GetPositionModifications()
        {
            if (_positionModifications != null)
            {
                return _positionModifications;
            }

            return _positionModifications = FillPositionModifications();
        }

        public override ICollection<IOrientationModification> GetAllModifications()
        {
            GetPositionModifications();
            GetRotationModifications();

            var allModifications = new List<IOrientationModification>();
            allModifications.AddRange(_positionModifications.GetAll());
            allModifications.AddRange(_rotationModifications.GetAll());

            return allModifications;
        }

        private IModificationsCollection<OrientationModification<Quaternion>> FillRotationModifications()
        {
            var collection = new ModificationsDictionary<OrientationModification<Quaternion>>(1);

            var headTilt = new BasicHeadTilt(_headTiltSettings);
            var headTiltModification = new HeadTiltModification(headTilt);

            collection.AddModification(headTiltModification);

            return collection;
        }

        private IModificationsCollection<OrientationModification<Vector3>> FillPositionModifications()
        {
            var collection = new ModificationsDictionary<OrientationModification<Vector3>>(1);

            var headBob = new BasicHeadBob(_headBobSettings);
            var headBobModification = new HeadBobModification(headBob);

            collection.AddModification(headBobModification);

            return collection;
        }
    }
}