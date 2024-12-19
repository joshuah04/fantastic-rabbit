namespace Sprint0.Interfaces.Player
{
    public interface IPlayerDirectionState
    {
        /* Obtains part of the composite key for sprite generation */
        public string GetDirectionState();

        /* Performs actions needed when entering this state */
        public void EnterState();

        /* Updates the player sprite based on the new direction state */
        public void Update();
    }
}
