using USB.Domain.Maps;

namespace USB.Domain
{
    public class Battle
    {
        public int Id { get; }
        public List<Player> Players { get; } = new List<Player>();
        public Map Map { get; }

        public Battle(int id, List<Player> players, Map map)
        {
            Id = id;
            Players = players;
            Map = map;
        }
    }
}
