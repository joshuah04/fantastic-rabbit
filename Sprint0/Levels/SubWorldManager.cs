using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Sprint0.Levels
{
    public class SubWorldManager
    {
        private Dictionary<String, Tuple<Vector2, int, int, string>> warpMappings;
        public SubWorldManager() 
        {
            this.warpMappings = new Dictionary<string, Tuple<Vector2, int, int, string>>();
        }

        public void AddWarpMapping(String warpName, Vector2 warpLocation, int leftBound, int rightBound, string color)
        {
            warpMappings.Add(warpName, new Tuple<Vector2, int, int, string>(warpLocation, leftBound, rightBound, color));
        }

        public Tuple<Vector2, int, int, string> GetWarpSpot(String warpName)
        {
            return warpMappings[warpName];
        }
    }
}
