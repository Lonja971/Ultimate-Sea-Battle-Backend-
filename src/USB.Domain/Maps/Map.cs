using System;
using System.Collections.Generic;
using System.Text;

namespace USB.Domain.Maps
{
    public class Map
    {
        public int Id { get; }
        public string Name { get; }
        public int Width { get; }
        public int Height { get; }

        public Map(int id, string name, int width, int height)
        {
            Id = id;
            Name = name;
            Width = width;
            Height = height;
        }
    }
}
