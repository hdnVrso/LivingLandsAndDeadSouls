using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera
{
    public class Camera : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            GetCoord();
        }

        void GetCoord()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
        }
        public float dumping = 1.5f;
        public Vector2 offset = new Vector2(2f, 1f);
        public int country;
    
        private Transform _player;
        private int _lastXPosition;
    }
}
