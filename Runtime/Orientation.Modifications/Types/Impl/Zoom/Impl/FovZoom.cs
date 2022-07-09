using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.Zoom.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.Zoom.Impl
{
    public class FovZoom : ZoomType
    {
        private readonly float _baseFov;
        private readonly ZoomSettings _settings;
        private readonly Camera _camera;
        
        public override void ZoomIn(float frameTime)
        {
            var previousFov = _camera.fieldOfView;
            var desiredFov = _baseFov * _settings.Factor;
            _camera.fieldOfView = Mathf.Lerp(previousFov, desiredFov, frameTime * _settings.Speed);
        }

        public override void ZoomOut(float frameTime)
        {
            var previousFov = _camera.fieldOfView;
            _camera.fieldOfView = Mathf.Lerp(previousFov, _baseFov,  _settings.Speed * frameTime);
        }

        public FovZoom(Camera camera, ZoomSettings settings, float baseFov)
        {
            _camera = camera;
            _settings = settings;
            _baseFov = baseFov;
        }
    }
}