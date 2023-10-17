using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tower
    {
        public float CoorX { get; }
        public List<GameObject> Rings { get; set; }

        public static readonly float FirstCoorY = -369f;

        public Tower(float coorX)
        {
            CoorX = coorX;
            Rings = new List<GameObject>();
        }
    }
}
