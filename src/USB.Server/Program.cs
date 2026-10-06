using USB.Application.Repositories;
using USB.Application.Services;
using USB.Domain;
using USB.Infrastructure.Repositories;

IMapRepository mapRepository = new JsonMapRepository("data/Maps");

var matchmakingService = new MatchmakingService(mapRepository);

Console.WriteLine("Hello, World!");

Player player1 = new Player(1, "MrStinger__");
Player player2 = new Player(2, "Davidk04");

matchmakingService.AddPlayerToQueue(player1);
Battle? battle = matchmakingService.AddPlayerToQueue(player2);

if (battle != null)
{
    Console.WriteLine("Battle Created!");
    Console.WriteLine($"Id: {battle.Id}");
}