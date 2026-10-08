using USB.Application.Repositories;
using USB.Application.Services;
using USB.Domain;
using USB.Domain.Maps;
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
}

//battle.Map.RemoveEntityFromCell(new CellPosition(X: 14, Y: 14), new EntityReference(USB.Domain.Enums.EntityType.Island, null));
battle.Map.RemoveEntityFromCell(new CellPosition(X: 12, Y:32), new ObstacleReference(USB.Domain.Enums.ObstacleType.Island));