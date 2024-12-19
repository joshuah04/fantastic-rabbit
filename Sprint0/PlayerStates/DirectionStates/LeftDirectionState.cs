using Sprint0.Interfaces.Player;
using Sprint0.Sound;
using System;

namespace Sprint0.MarioStates.DirectionStates
{
    public class LeftDirectionState : IPlayerDirectionState
    {
        /* Reference to the player */
        private IPlayer player;

        public LeftDirectionState(IPlayer player)
        {
            this.player = player;
        }

        /* Obtains direction string for the composite key */
        public string GetDirectionState()
        {
            return "Left";
        }

        /* Handles entering the left-facing Mario state */
        public void EnterState()
        {
            Console.WriteLine("Entering MarioJumpState and playing jump sound");
            SoundManager.Instance.PlaySound("jumpSmall");
        }

        public void Update()
        {
        }
    }
}
