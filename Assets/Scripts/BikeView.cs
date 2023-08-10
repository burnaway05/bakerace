using UnityEngine;

namespace Core
{
    internal class BikeView : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "TerrainTrigger")
            {
                Run.Instance.Game.SpawnTerrain();
            }
        }
    }
}