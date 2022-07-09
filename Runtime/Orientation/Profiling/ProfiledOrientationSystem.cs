using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using UnityEngine.Profiling;

namespace Depra.Pawn.Runtime.Orientation.Profiling
{
    public class ProfiledOrientationSystem : IOrientationSystem
    {
        private readonly IOrientationSystem _baseSystem;
        private readonly string _sampleName;
        
        public void OnUpdate(float timeStep)
        {
           Profiler.BeginSample(_sampleName);
           
           _baseSystem.OnUpdate(timeStep);
           
           Profiler.EndSample();
        }

        public ProfiledOrientationSystem(IOrientationSystem baseSystem)
        {
            _baseSystem = baseSystem;
            _sampleName = _baseSystem.GetType().Name;
        }
    }
}