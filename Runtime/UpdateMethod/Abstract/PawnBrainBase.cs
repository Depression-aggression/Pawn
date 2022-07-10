using Depra.Pawn.Runtime.UpdateMethod.Impl;
using Depra.Pawn.Runtime.UpdateMethod.Interfaces;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Profiling;

namespace Depra.Pawn.Runtime.UpdateMethod.Abstract
{
    public abstract class PawnBrainBase : MonoBehaviour, IPawnUpdateHandler
    {
        private IPawnUpdateHandler _innerUpdateHandler;

        internal IPawnUpdateHandler UpdateHandler => this;

        [PublicAPI]
        public void SetPause(bool pauseState)
        {
            enabled = pauseState == false;
        }

        internal void Initialize(UpdatablePawnBehavior[] behaviors)
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