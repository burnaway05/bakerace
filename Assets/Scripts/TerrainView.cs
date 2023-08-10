using UnityEngine;

namespace Core
{
    internal class TerrainView : MonoBehaviour
    {
        [SerializeField] private Collider2D _terrainEnter;

        public void DisableTrigger()
        {
            _terrainEnter.gameObject.SetActive(false);
        }
    }
}
