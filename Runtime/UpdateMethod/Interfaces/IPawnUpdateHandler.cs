namespace Depra.Pawn.Runtime.UpdateMethod.Interfaces
{
    internal interface IPawnUpdateHandler
    {
        void UpdateManual();

        void UpdateFixed();

        void UpdateLate();
    }
}