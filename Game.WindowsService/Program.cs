using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Game.ActorModel.Actors;
using Topshelf;

namespace Game.WindowsService
{
    public class GameStateService
    {
        private ActorSystem ActorSystemInstance;

        public void Start()
        {
            ActorSystemInstance = ActorSystem.Create("GameSystem");

            var gameController = ActorSystemInstance.ActorOf<GameControllerActor>("GameController");
        }

        public void Stop()
        {
            ActorSystemInstance.Shutdown();
            ActorSystemInstance.AwaitTermination(TimeSpan.FromSeconds(2));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(gameService =>
            {
                gameService.Service<GameStateService>(s =>
                {
                    s.ConstructUsing(game => new GameStateService());
                    s.WhenStarted(game => game.Start());
                    s.WhenStopped(game => game.Stop());
                });

                gameService.RunAsLocalSystem();
                gameService.StartAutomatically();

                gameService.SetDescription("AkkaDistDemo Game Topshelf Service");
                gameService.SetDisplayName("AkkaDistDemoGame");
                gameService.SetServiceName("AkkaDistDemoGame");
            });
        }
    }
}
