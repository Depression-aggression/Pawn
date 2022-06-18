using System;

namespace Depra.Pawn.Runtime.Locomotion.Commands
{
    public class StopMoveCommand : IEmptyTranslationCommand
    {
        public Action DirectionCleared { get; set; }
        
        public void Execute()
        {
            DirectionCleared.Invoke();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}