namespace Depra.Pawn.Runtime.UpdateMethod.Interfaces
{
    public interface IPawnUpdateHandler
    {
        void UpdateManual();

        void UpdateFixed();

        void UpdateLate();
    }
}