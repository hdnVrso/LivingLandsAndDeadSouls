using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HealthFight
{
    public class Gun : MonoBehaviour
    {
        void Start()
        {
            ammoCount = 0;
            _originID = GameObject.Find("Player").GetInstanceID();
            _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            _ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
            damage = 0;
            _damageRadius = 0.2f;
            fireRate = 0;
            _ammoText.text = ammoCount.ToString();
        }

        public void Use()
        {
            _direction = _playerController.moveVelocity;
            if (ammoCount <= 0)
                return;
            for (int i = 0; i < fireRate; ++i)
            {
                --ammoCount;
                _ammoText.text = ammoCount.ToString();
                _bullet = Bullet.Create(_playerController.transform, _direction, 5f * fireRate, damage + damageBuff,
                    _damageRadius, _originID);
                if (ammoCount <= 0)
                    return;
            }
        }


        //data members
        public int fireRate;
        public int ammoCount;
        public int damage;
        public int damageBuff = 10;

        private int _originID;
        private Vector2 _direction;
        private float _damageRadius;
        private GameObject _bullet;
        private PlayerController _playerController;
        private Text _ammoText;
    }
}//end of namespace HealthFight