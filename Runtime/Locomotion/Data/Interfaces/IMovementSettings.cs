namespace Depra.Pawn.Runtime.Locomotion.Data.Interfaces
{
    public interface IMovementSettings
    {
        float MaxSpeed { get; }
        
        float Acceleration { get; }
        
        float Deceleration { get; }
    }
}