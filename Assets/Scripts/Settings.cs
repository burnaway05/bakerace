using UnityEngine;

namespace Core
{
    internal class Settings : ScriptableObject
    {
        public GameObject BikePrefab;
        public GameObject TerrainPrefab;

        public Vector3 StartBikePosition = new Vector3(-3, 1, 0);
        public Vector3 StartTerrainPosition = new Vector3(-32, -26, 0);
    }
}