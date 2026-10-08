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
        public List<CellPosition> Islands { get; }
        public Dictionary<CellPosition, ObstacleReference> BlockedCells { get; } = new Dictionary<CellPosition, ObstacleReference>();

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
                    ObstacleReference island = new ObstacleReference(ObstacleType.Island);
                    AddEntityToCell(islands[i], island);
                }
            }
        }

        public bool IsInsideMapBounds(CellPosition pos)
        {
            return (pos.X >= 0 && pos.X < Width) && (pos.Y >= 0 && pos.Y < Height);
        }

        public bool RemoveCell(CellPosition pos)
        {
            return BlockedCells.Remove(pos);
        }

        public bool AddEntityToCell(CellPosition pos, ObstacleReference obstacleRef)
        {
            if (!IsInsideMapBounds(pos)) return false;
            if (BlockedCells.ContainsKey(pos)) return false;

            BlockedCells.Add(pos, obstacleRef);

            return true;
        }

        public bool AddEntityToCells(ObstacleReference obstacleRef, List<CellPosition> cellPositions)
        {
            foreach (CellPosition cellPosition in cellPositions)
            {
                AddEntityToCell(cellPosition, obstacleRef);
            }
            return true;
        }

        public bool RemoveEntityFromCell(CellPosition pos, ObstacleReference obstacleRef)
        {
            if (!BlockedCells.ContainsKey(pos)) return false;
            ObstacleReference savedRef = BlockedCells[pos];
            if (savedRef != obstacleRef) return false;
            
            return RemoveCell(pos);
        }

        public bool RemoveEntityFromCells(ObstacleReference obstacleRef, List<CellPosition> cellPositions)
        {
            foreach (CellPosition cellPos in cellPositions)
            {
                RemoveEntityFromCell(cellPos, obstacleRef);
            }
            return true;
        }
    }
}
