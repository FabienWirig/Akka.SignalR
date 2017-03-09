using System;
using Game.ActorModel.ExternalSystems;
using Microsoft.AspNet.SignalR;

namespace Game.Web.Models
{
    public class SignalRGameEventPusher : IGameEventsPusher
    {
        private static readonly IHubContext _gameHubContext;

        static SignalRGameEventPusher()
        {
            _gameHubContext = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
        }

        public void PlayerJoined(string playerName, int playerHealth)
        {
            _gameHubContext.Clients.All.playerJoined(playerName, playerHealth);
        }

        public void UpdatePlayerHealth(string playerName, int playerHealth)
        {
            _gameHubContext.Clients.All.updatePlayerHealth(playerName, playerHealth);
        }
    }
}