using System;
using System.Collections.Generic;
using System.Text;

namespace USB.Domain
{
    public class Player
    {
        int Id { get; }
        string Name { get; }

        public Player(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
