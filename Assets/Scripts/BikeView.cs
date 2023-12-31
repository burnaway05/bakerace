﻿using UnityEngine;

namespace Core
{
    internal class BikeView : MonoBehaviour
    {
        [SerializeField] private HingeJoint2D _backWheel;
        [SerializeField] private HingeJoint2D _frontWheel;
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private BackTire _backTire;
        [SerializeField] private FrontTire _frontTire;

        public HingeJoint2D BackWheel => _backWheel;
        public HingeJoint2D FrontWheel => _frontWheel;
        public Rigidbody2D Body => _body;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "TerrainTrigger")
            {
                Run.Instance.Game.SpawnTerrain();
            }
        }

        public bool IsBackTireOnGround()
        {
            return _backTire.OnGround();
        }

        public bool IsFrontTireOnGround()
        {
            return _frontTire.OnGround();
        }
    }
}