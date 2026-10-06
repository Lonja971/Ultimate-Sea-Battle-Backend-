# Project structure

```
SeaBattle/
│
├── SeaBattle.sln
│
├── src/
│   │
│   ├── SeaBattle.Domain/
│   │   ├── Players/
│   │   │   └── Player.cs
│   │   │
│   │   ├── Battles/
│   │   │   └── Battle.cs
│   │   │
│   │   ├── Ships/
│   │   │   └── Ship.cs
│   │   │
│   │   ├── Projectiles/
│   │   │   └── Projectile.cs
│   │   │
│   │   ├── Maps/
│   │   │   └── Map.cs
│   │   │
│   │   └── Common/
│   │       └── Position.cs
│   │
│   ├── SeaBattle.Application/
│   │   ├── Matchmaking/
│   │   │   └── MatchmakingService.cs
│   │   │
│   │   ├── Battles/
│   │   │   └── BattleService.cs
│   │   │
│   │   └── Projectiles/
│   │       └── ProjectileFactory.cs
│   │
│   ├── SeaBattle.Infrastructure/
│   │   ├── Maps/
│   │   │   └── JsonMapRepository.cs
│   │   │
│   │   └── Persistence/
│   │       └── ...
│   │
│   └── SeaBattle.Server/
│       ├── Networking/
│       │   ├── ClientConnection.cs
│       │   └── SocketServer.cs
│       │
│       ├── Program.cs
│       └── ...
│
├── tests/
│   ├── SeaBattle.Domain.Tests/
│   ├── SeaBattle.Application.Tests/
│   └── SeaBattle.Server.Tests/
│
└── data/
    └── Maps/
        ├── ocean.json
        └── islands.json
```