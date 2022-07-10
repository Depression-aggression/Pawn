namespace Depra.Pawn.Runtime.ReadInput.Interfaces
{
    public interface ILocomotionInputReader
    {
        float Horizontal();
        
        float Vertical();

        bool IsJumpPressed();

        bool IsWalkPressed();
        
        bool IsSprintPressed();
        
        bool IsCrouchPressed();
    }
}