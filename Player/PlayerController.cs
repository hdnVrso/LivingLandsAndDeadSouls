using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
{
    void Start()
    {
        _height = GameObject.Find("ParametersManager").GetComponent
            <Menu.ParameterManager>().tmpSize.y;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _soundOfRun = GameObject.Find("RunSound").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        mContr = GameObject.Find("JoystickBG").GetComponent<MobileController>();
        Debug.Log("Controller is initialized");
        rigidBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (mContr.Horizontal() > 0.9)
        {
                direction = 2;
                animator.Play("Move_right");
            }
            else if (mContr.Horizontal() < -0.9)
            {
                direction = 3;
                animator.Play("Move_left");
            }
            else 
            {
                if (mContr.Vertical() > 0)
                {
                    direction = 1;
                    animator.Play("Move_back");
                }
                else if (mContr.Vertical() < 0)
                {
                    direction = 0;
                    animator.Play("Move_face");
                }
                else
                {
                    switch (direction)
                    {
                        case 0:
                            animator.Play("Idle_face");
                            break;
                        case 1 :
                            animator.Play("Idle_back");
                            break;
                        case 2:
                            animator.Play("Idle_right");
                            break;
                        case 3:
                            animator.Play("Idle_left");
                            break;
                    }
                }
            }
        
            _dirX = mContr.Horizontal();
            _dirY = mContr.Vertical();
            Vector2 moveInput = new Vector2(_dirX, _dirY);
            moveVelocity = moveInput * playerSpeed;
            if (_dirX == 0 && _dirY == 0)
            {
                _soundOfRun.Stop();
            }
            else
            {
                if (!_soundOfRun.isPlaying)
                {
                    _soundOfRun.Play();
                }
            }

    }
    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + moveVelocity);
        _spriteRenderer.sortingOrder = _height / 2 - (int)gameObject.transform.position.y + 1;
    }
    
    public bool needToGo = false;
    public bool needToFire = false;
    public int direction = 0;//0-вниз 1-вверх 2-вправо 3-влево
    public Animator animator;
    public float playerSpeed = 0.25f;
    public Vector2 moveVelocity;
    public MobileController mContr;

    private int _height;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _soundOfRun;
    private float _dirX;
    private float _dirY;
    private GameObject _bullet;
    private Rigidbody2D rigidBody;
    private Animator _anim;
    
}
}
