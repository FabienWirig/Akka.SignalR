namespace Game.ActorModel.Messages
{
    public class JoinGameMessage
    {
        public string PlayerName { get; private set; }

        public JoinGameMessage(string playerName)
        {
            PlayerName = playerName;
        }
    }
}
