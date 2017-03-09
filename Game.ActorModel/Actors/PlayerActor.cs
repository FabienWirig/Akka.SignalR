using Akka.Actor;
using Game.ActorModel.Messages;

namespace Game.ActorModel.Actors
{
    public class PlayerActor : ReceiveActor
    {
        private readonly string _playerName;
        private int _health;

        public PlayerActor(string playerName)
        {
            _playerName = playerName;
            _health = 100;

            Receive<AttackPlayerMessage>(
                message =>
                {
                    _health -= 20;

                    Sender.Tell(new PlayerHealthChangedMessage(_playerName, _health));
                });

            Receive<RefreshPlayerStatusMessage>(
                message =>
                {
                    Sender.Tell(new PlayerStatusMessage(_playerName, _health));
                });
        }
    }
}
