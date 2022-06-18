namespace Depra.Pawn.Runtime.Modules.ReadInput.Interfaces
{
    public interface IMotorInputReader
    {
        float Horizontal();
        
        float Vertical();

        bool IsJumpPressed();

        bool IsCrouchPressed();
    }
}