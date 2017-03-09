using Akka.Actor;
using Game.ActorModel.ExternalSystems;
using Game.ActorModel.Messages;

namespace Game.ActorModel.Actors
{
    public class SignalRBridgeActor : ReceiveActor
    {
        private readonly IGameEventsPusher _gameEventPusher;
        private readonly IActorRef _gameController;

        public SignalRBridgeActor(IGameEventsPusher gameEventPusher, IActorRef gameController)
        {
            _gameEventPusher = gameEventPusher;
            _gameController = gameController;


            Receive<JoinGameMessage>(
                message =>
                {
                    _gameController.Tell(message);
                });

            Receive<AttackPlayerMessage>(
                message =>
                {
                    _gameController.Tell(message);   
                });


            Receive<PlayerStatusMessage>(
                message =>
                {
                    _gameEventPusher.PlayerJoined(message.PlayerName, message.Health);
                });


            Receive<PlayerHealthChangedMessage>(
                message =>
                {
                    _gameEventPusher.UpdatePlayerHealth(message.PlayerName, message.Health);
                });
        }
    }
}
