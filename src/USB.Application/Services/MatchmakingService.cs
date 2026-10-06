using USB.Application.Repositories;
using USB.Domain;
using USB.Domain.Maps;

namespace USB.Application.Services
{
    public class MatchmakingService
    {
        private readonly IMapRepository _mapRepository;
        private int _battleIdCounter = 1;
        public Queue<Player> PlayersQueue { get; } = new Queue<Player>();
        public List<Battle> BattleList { get; } = new List<Battle>();

        public MatchmakingService(IMapRepository mapRepository)
        {
            _mapRepository = mapRepository;
        }

        private int GenerateBattleId()
        {
            return _battleIdCounter++;
        }

        public Battle? AddPlayerToQueue(Player player)
        {
            PlayersQueue.Enqueue(player);
            return TryCreateBattle();
        }

        private Battle? TryCreateBattle()
        {
            if (PlayersQueue.Count < 2) return null;

            List<Player> battlePlayers = new List<Player>
            {
                PlayersQueue.Dequeue(),
                PlayersQueue.Dequeue()
            };

            Map map = _mapRepository.GetRandomMap();

            Battle newBattle = new Battle(
                GenerateBattleId(),
                battlePlayers,
                map
            );
            BattleList.Add(newBattle);

            return newBattle;
        }
    }
}
