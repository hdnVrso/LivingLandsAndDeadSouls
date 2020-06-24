using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyFollow : MonoBehaviour
    {
        void Start()
        {
            _target = GameObject.Find("Player").GetComponent<Transform>();
            _originID = this.gameObject.GetInstanceID();
            _fireCount = fireRate;
            _enemylogic = this.gameObject.GetComponent<EnemyLogic>();
            _enemyAnimator = this.gameObject.GetComponent<EnemyAnimator>();
            _fireCount = fireRate;
        }
        
        void Update()
        {
            if (Vector2.Distance(transform.position, _target.position) > stoppingDistance &&
                Vector2.Distance(transform.position, _target.position) < followDistance)
            {
               //_enemylogic.isActive = false;
                _enemyAnimator.isActive = true;
                transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);

                if (Math.Abs(transform.position.x - _target.transform.position.x) < 5)
                {
                    directionX = 0;
                }
                else if (transform.position.x > _target.transform.position.x)
                {
                    directionX = -1;
                }
                else
                {
                    directionX = 1;
                }
                
                if (transform.position.y == _target.transform.position.y)
                {
                    directionY = 0;
                }
                else if (transform.position.y > _target.transform.position.y)
                {
                    directionY = -1;
                }
                else
                {
                    directionY = 1;
                }
            }
            else
            {
               // _enemylogic.isActive = true;
               // _enemyAnimator.isActive = false;

            }
            
            if (Vector2.Distance(transform.position, _target.position) < shotDistance && _fireCount <= 0)
            {
                _bullet = HealthFight.Bullet.CreateFromBandit(this.transform, _target, 30f, 5, 0.3f, _originID);
                _fireCount = fireRate;
            }
            --_fireCount;
        }
        
        
        //data members
        public float speed;
        public int directionX;
        public int directionY;// 0 - y1=y2; 1 - x1=x2; 
        public float stoppingDistance;
        public float followDistance;
        public float shotDistance;
        public int fireRate;
        
        private Transform _target;
        private Rigidbody2D _targetRigidBody;
        private int _originID;
        private GameObject _bullet;
        private int _fireCount = 10;
        private EnemyLogic _enemylogic;
        private EnemyAnimator _enemyAnimator;
    } 
}//end of namespace Enemy
