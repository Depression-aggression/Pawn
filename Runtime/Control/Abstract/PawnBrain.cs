using Depra.Pawn.Runtime.UpdateMethod.Abstract;
using Depra.Pawn.Runtime.UpdateMethod.Impl;
using Depra.Pawn.Runtime.UpdateMethod.Interfaces;
using UnityEngine;
using UnityEngine.Profiling;

namespace Depra.Pawn.Runtime.Control.Abstract
{
    public abstract class PawnBrain : MonoBehaviour, IPawnUpdateHandler
    {
        private IPawnUpdateHandler _innerUpdateHandler;
        
        protected IPawnUpdateHandler UpdateHandler => this;

        public void SetPause(bool pauseState)
        {
            enabled = pauseState == false;
        }
        
        protected void Initialize(UpdatablePawnBehavior[] behaviors)
        {
            _innerUpdateHandler = new PawnUpdateHandler(behaviors);
        }
        
        void IPawnUpdateHandler.UpdateManual()
        {
            Profiler.BeginSample("Pawn Manual Update");
            
            _innerUpdateHandler.UpdateManual();
            
            Profiler.EndSample();
        }

        void IPawnUpdateHandler.UpdateFixed()
        {
            Profiler.BeginSample("Pawn Fixed Update");
            
            _innerUpdateHandler.UpdateFixed();
            
            Profiler.EndSample();
        }

        void IPawnUpdateHandler.UpdateLate()
        {
            Profiler.BeginSample("Pawn Late Update");
            
            _innerUpdateHandler.UpdateLate();
            
            Profiler.EndSample();
        }
    }
}