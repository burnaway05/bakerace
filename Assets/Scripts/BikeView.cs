using UnityEngine;

namespace Core
{
    internal class BikeView : MonoBehaviour
    {
        [SerializeField] private HingeJoint2D _backWheel;
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private BackTire _backTire;

        public HingeJoint2D BackWheel => _backWheel;
        public Rigidbody2D Body => _body;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "TerrainTrigger")
            {
                Run.Instance.Game.SpawnTerrain();
            }
        }

        public bool IsOnGround()
        {
            return _backTire.OnGround();
        }
    }
}