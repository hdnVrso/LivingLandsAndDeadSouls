using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            _animator = this.gameObject.GetComponent<Animator>();
            _enemyFollow = this.gameObject.GetComponent<EnemyFollow>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isActive == false)
                return;
            if (_enemyFollow.directionX == 0)
            {
                if (_enemyFollow.directionY == 0)
                {

                }
                else if (_enemyFollow.directionY > 0)
                {
                    _animator.Play("MoveBack");
                }
                else
                {
                    _animator.Play("MoveFace");
                }
            }
            else if (_enemyFollow.directionX > 0)
            {
                _animator.Play("MoveRight");
            }
            else
            {
                _animator.Play("MoveLeft");
            }
        }

        //data members
        private Animator _animator;
        private EnemyFollow _enemyFollow;
        public bool isActive = false;
    }
}//end of namespace Enemy