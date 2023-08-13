using UnityEngine;

namespace Core
{
    internal class FrontTire : MonoBehaviour
    {
        private bool _isOnGround;

        public bool OnGround()
        {
            return _isOnGround;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Terrain")
            {
                _isOnGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.tag == "Terrain")
            {
                _isOnGround = false;
            }
        }
    }
}