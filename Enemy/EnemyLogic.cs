using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyLogic : MonoBehaviour
    {
        private void Start()
        {
            _myRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
            _animator = this.gameObject.GetComponent<Animator>();
            _waitCounter = waitTime;
            _walkCounter = waitTime;
        }
        
        private void Update()
        {
            if (isActive == false)
            {
                _myRigidBody.velocity = new Vector2(0, 0);
                return;
            }

            if (isWalking)
            {
                _walkCounter -= Time.deltaTime;
                switch (_walkDirection)
                {
                    case 0:
                        _myRigidBody.velocity = new Vector2(0, moveSpeed);
                        _animator.Play("MoveBack");
                        break;
                    case 1:
                        _myRigidBody.velocity = new Vector2(moveSpeed, 0);
                        _animator.Play("MoveRight");
                        break;
                    case 2:
                        _myRigidBody.velocity = new Vector2(0, -moveSpeed);
                        _animator.Play("MoveFace");
                        break;
                    case 3:
                        _myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                        _animator.Play("MoveLeft");
                        break;
                }

                if (!(_walkCounter < 0)) return;

                isWalking = false;
                _waitCounter = waitTime;
                Debug.Log("Hey i am here");
                switch (_walkDirection)
                {
                    case 0:
                        _animator.Play("IdleBack");
                        break;
                    case 1:
                        _animator.Play("IdleRight");
                        break;
                    case 2:
                        _animator.Play("IdleFace");
                        break;
                    case 3:
                        _animator.Play("IdleLeft");
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
            _walkDirection = Random.Range(0, 4);
            isWalking = true;
            _walkCounter = waitTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<HealthFight.DamageComponent>() != null && other.name == "Player")
                return;
            switch (_walkDirection)
            {
                case 0:
                    _walkDirection = 2;
                    break;
                case 2:
                    _walkDirection = 0;
                    break;
                case 1:
                    _walkDirection = 3;
                    break;
                default:
                    _walkDirection = 1;
                    break;
            }
            if (isWalking != false) 
                return;
            isWalking = true;
            _waitCounter = 0;
            _walkCounter = waitTime;
        }

        //data members
        public float moveSpeed;
        public float waitTime;
        public bool isWalking;

        private Rigidbody2D _myRigidBody;
        private Animator _animator;
        private float _walkCounter;
        private float _waitCounter;
        private int _walkDirection;
        public bool isActive = true;
    }
}//end of namespace Enemy