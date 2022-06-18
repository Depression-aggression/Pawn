using JetBrains.Annotations;

namespace Depra.Pawn.Runtime.Commands.Interfaces
{
    /// <summary>
    /// Common interface for commands.
    /// </summary>
    [PublicAPI]
    public interface IPawnCommand
    {
        /// <summary>
        /// Method called to execute command.
        /// </summary>
        void Execute();

        /// <summary>
        /// Method called to undo command execution.
        /// </summary>
        void Undo();
    }
}
