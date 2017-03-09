namespace Game.ActorModel.Messages
{
    public class PlayerHealthChangedMessage
    {
        public string PlayerName { get; private set; }
        public int Health { get; private set; }

        public PlayerHealthChangedMessage(string playerName, int health)
        {
            PlayerName = playerName;
            Health = health;
        }

    }
}
