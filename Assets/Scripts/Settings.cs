using UnityEngine;

namespace Core
{
    internal class Settings : ScriptableObject
    {
        public GameObject BikePrefab;
        public GameObject TerrainPrefab;

        public float CameraSpeed = 2;
        public int MaxBackTireTorque = -3000;
        public float BackTireTorqueStep = -1200f;
        public int BrakeStep = 10;
        public Vector3 StartBikePosition = new Vector3(-3, 0, 0);
        public Vector3 StartTerrainPosition = new Vector3(-32, -26, 0);
    }
}