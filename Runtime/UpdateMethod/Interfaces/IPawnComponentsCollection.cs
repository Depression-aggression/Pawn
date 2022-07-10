using System;
using Depra.Pawn.Runtime.UpdateMethod.Abstract;

namespace Depra.Pawn.Runtime.UpdateMethod.Interfaces
{
    internal interface IPawnComponentsCollection
    {
        void AddComponent(UpdatablePawnBehavior behavior);

        void RemoveComponent(UpdatablePawnBehavior behavior);

        void RemoveComponent(Type behaviorType);
    }
}