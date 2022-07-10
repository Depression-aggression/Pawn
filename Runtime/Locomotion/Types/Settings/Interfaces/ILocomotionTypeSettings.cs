namespace Depra.Pawn.Runtime.Locomotion.Types.Settings.Interfaces
{
    public interface ILocomotionTypeSettings
    {
        float MaxSpeed { get; }
        
        float SpeedMultiplier { get; }
        
        float Acceleration { get; }
        
        float Deceleration { get; }
    }
}