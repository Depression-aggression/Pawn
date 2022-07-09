using Depra.Pawn.Runtime.Orientation.Modifications.Types.Interfaces;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.Smoothing
{
    public class DegreeAxisSmoothing : IDegreeAxisModification
    {
        private const float NormalizeConstant = 100f;
        
        private readonly float _sensitivity;

        public float ModifyInputAxis(float axis, float frameTime) => axis * _sensitivity * NormalizeConstant * frameTime;

        public DegreeAxisSmoothing(float sensitivity)
        {
            _sensitivity = sensitivity;
        }
    }
}