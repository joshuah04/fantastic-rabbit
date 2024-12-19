using Sprint0.Interfaces.Player;
using Sprint0.Sound;
using System;

namespace Sprint0.MarioStates.DirectionStates
{
    public class RightDirectionState : IPlayerDirectionState
    {
        /* Reference to the player */
        private IPlayer player;

        public RightDirectionState(IPlayer player)
        {
            this.player = player;
        }

        /* Obtains direction string for the composite key */
        public string GetDirectionState()
        {
            return "Right";
        }

        /* Handles entering the right-facing Mario state */
        public void EnterState()
        {
            Console.WriteLine("Entering MarioJumpState and playing jump sound");
            SoundManager.Instance.PlaySound("jumpSmall");
        }

        /* Transition for this state only occurs when A or D keys pressed */
        public void Update()
        {
        }
    }
}
