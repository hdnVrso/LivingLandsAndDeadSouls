using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Animals
{
    public class CommonAnimalMovement : MonoBehaviour
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
                _walkCounter -= Time.deltaTime;
                switch (_walkDirection)
                {
                    case 0:
                        _myRigidBody.velocity = new Vector2(0, moveSpeed);
                        _animator.Play("move_up");
                        break;
                    case 1:
                        _myRigidBody.velocity = new Vector2(moveSpeed, 0);
                        _animator.Play("move_right");
                        break;
                    case 2:
                        _myRigidBody.velocity = new Vector2(0, -moveSpeed);
                        _animator.Play("move_down");
                        break;
                    case 3:
                        _myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                        _animator.Play("move_left");
                        break;
                }

                if (!(_walkCounter < 0)) return;
                
                isWalking    = false;
                _waitCounter = waitTime;
                switch (_walkDirection)
                {
                    case 0:
                        _animator.Play("stay_up");
                        break;
                    case 1:
                        _animator.Play("stay_right");
                        break;
                    case 2:
                        _animator.Play("stay_down");
                        break;
                    case 3:
                        _animator.Play("stay_left");
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
            isWalking      = true;
            _walkCounter   = waitTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<HealthFight.DamageComponent>() != null)
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
            if (isWalking != false) return;
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
    }
}//end of namespace Animals