using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HealthFight;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Animals
{
    public class EnemyAnimalMovement : MonoBehaviour
    {
        void Start()
        {
            _myRigidBody = GetComponent<Rigidbody2D>();
            _animator    = GetComponent<Animator>();
            _waitCounter = waitTime;
            _walkCounter = waitTime;
        }
        
        void Update()
        {
            if (isWalking)
            {
                var a = Random.Range(-1.0f, 1.0f);
                _walkCounter -= Time.deltaTime;
                switch (_walkDirection)
                {
                    case 0:
                        _myRigidBody.velocity = new Vector2(-moveSpeed, a);
                        _animator.Play("Move_left");
                        break;
                    case 1:
                        _myRigidBody.velocity = new Vector2(moveSpeed, a);
                        _animator.Play("Move_right");
                        break;
                }

                if (!(_walkCounter < 0)) return;
                
                isWalking    = false;
                _waitCounter = waitTime;
                switch (_walkDirection)
                {
                    case 0:
                        _animator.Play("Idle_left");
                        break;
                    case 1:
                        _animator.Play("Idle_right");
                        break;
                }
            }
            else
            {
                _waitCounter -= Time.deltaTime;
                _myRigidBody.velocity = Vector2.zero;
                if (_waitCounter < 0)
                    ChoseDirection();
            }
        }

        private void ChoseDirection()
        {
            _walkDirection = Random.Range(0, 2);
            isWalking      = true;
            _walkCounter   = waitTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == "Player")
            {
                if (other.transform.position.x > transform.position.x)
                    _animator.Play("Attack_right");
                else
                    _animator.Play("Attack_left");
                other.GetComponent<HealthComponent>().DecreaseHealth(damage);
                return;
            }
            if (other.GetComponent<HealthFight.DamageComponent>() != null)
                return;
            switch (_walkDirection)
            {
                case 0:
                    _walkDirection = 1;
                    break;
                case 1:
                    _walkDirection = 0;
                    break;
            }
            if (isWalking != false) return;
            isWalking = true;
            _waitCounter = 0;
            _walkCounter = waitTime;
        }
        

        //data members
        public float moveSpeed;
        public float waitTime;
        public bool isWalking;
        public int damage;
        
        private Rigidbody2D _myRigidBody;
        private Animator _animator;
        private float _walkCounter;
        private float _waitCounter;
        private int _walkDirection;
    }
}// end of namespace Animals
