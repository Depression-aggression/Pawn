using Depra.Pawn.Runtime.Orientation.Targets.Abstract;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Abstract
{
    public abstract class SoloPawnRotor : PawnRotor
    {
        protected abstract OrientationOrigin SetupOrigin();
        
        protected override OrientationOrigin[] SetupOrigins()
        {
            return new[] { SetupOrigin() };
        }
    }
}