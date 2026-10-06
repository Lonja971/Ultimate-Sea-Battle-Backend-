using System;
using System.Collections.Generic;
using System.Text;
using USB.Domain.Enums;

namespace USB.Domain.Maps
{
    public class Map
    {
        public int Id { get; }
        public string Name { get; }
        public int Width { get; }
        public int Height { get; }
        public List<CellPosition> Islands { get; } = new List<CellPosition>();
        public Dictionary<CellPosition, List<EntityReference>> OccupiedCells { get; } = new Dictionary<CellPosition, List<EntityReference>>();

        public Map(int id, string name, int width, int height, List<CellPosition> islands)
        {
            Id = id;
            Name = name;
            Width = width;
            Height = height;
            
            if (islands.Count > 0)
            {
                for (int i = 0; i < islands.Count; i++)
                {
                    EntityReference island = new EntityReference(Enums.EntityType.Island, null);
                    AddToCell(islands[i], island);
                }
            }
        }

        public bool IsInsideMapBounds(CellPosition pos)
        {
            return (pos.X >= 0 && pos.X < Width) && (pos.Y >= 0 && pos.Y < Height);
        }

        public bool RemoveCell(CellPosition pos)
        {
            return OccupiedCells.Remove(pos);
        }

        public bool AddToCell(CellPosition pos, EntityReference entityRef)
        {
            if (!IsInsideMapBounds(pos)) return false;

            if (!OccupiedCells.TryGetValue(pos, out var entities))
            {
                entities = new List<EntityReference>();
                OccupiedCells.Add(pos, entities);
            }

            OccupiedCells[pos].Add(entityRef);
            return true;
        }

        public bool RemoveEntityFromCell(CellPosition pos, EntityReference entityRef)
        {
            if (!OccupiedCells.ContainsKey(pos)) return false;
            List<EntityReference> posEntities = OccupiedCells[pos];
            if (posEntities.Count == 0) return false;

            for (int i = posEntities.Count - 1; i >= 0; i--)
            {
                if (entityRef == posEntities[i])
                {
                    OccupiedCells[pos].Remove(posEntities[i]);
                }
            }

            if (OccupiedCells[pos].Count == 0)
            {
                RemoveCell(pos);
            }

            return true;
        }
    }
}
