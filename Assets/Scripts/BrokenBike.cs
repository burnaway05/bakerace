using Core;
using UnityEngine;

namespace Assets.Scripts
{
    internal class BrokenBike : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Terrain")
            {
                Run.Instance.Game.Restart();
            }
        }
    }
}
