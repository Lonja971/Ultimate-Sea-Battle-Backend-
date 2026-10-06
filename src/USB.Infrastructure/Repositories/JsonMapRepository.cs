using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using USB.Application.Repositories;
using USB.Domain.Maps;

namespace USB.Infrastructure.Repositories
{
    public class JsonMapRepository : IMapRepository
    {
        private readonly string _mapsDirectory;

        public JsonMapRepository(string mapsDirectory)
        {
            _mapsDirectory = mapsDirectory;
        }

        public Map GetRandomMap()
        {
            var files = Directory.GetFiles(_mapsDirectory, "*.json");

            if (files.Length == 0) throw new InvalidOperationException("No maps found!");

            var random = Random.Shared;
            var file = files[random.Next(files.Length)];
            var json = File.ReadAllText(file);
            Map? map = JsonSerializer.Deserialize<Map>(json);

            if (map == null) throw new InvalidOperationException($"Failed to load map: {file}");

            return map;
        }
    }
}
