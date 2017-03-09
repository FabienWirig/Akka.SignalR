using Akka.Actor;
using Game.ActorModel.Messages;
using Microsoft.AspNet.SignalR;

namespace Game.Web.Models
{
    public class GameHub : Hub
    {
        public void JoinGame(string playerName)
        {
            GameActorSystem
                .ActorReferences
                .SignalRBridge
                .Tell(new JoinGameMessage(playerName));
        }

        public void Attack(string playerName)
        {
            GameActorSystem
                .ActorReferences
                .SignalRBridge
                .Tell(new AttackPlayerMessage(playerName));
        }
    }
}