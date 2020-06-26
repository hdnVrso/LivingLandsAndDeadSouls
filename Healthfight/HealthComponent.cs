using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;


namespace HealthFight
{
    public class HealthComponent : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            _death = false;
            originID = this.gameObject.GetInstanceID();
            if (!isPlayer)
            {
                CreateHealthBar();
            }
            else
            {
                var barObj = GameObject.Find("PlayerHealthBar");
                _bar = barObj.GetComponent<HealthBar>();
            }

            var circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
            circleCollider.radius = 0.3f;
            circleCollider.isTrigger = true;
            health = 100;
            _animator = this.gameObject.GetComponent<Animator>();
        }

        private void CreateHealthBar()
        {
            _bar = HealthBar.Create(this.gameObject.transform, new Vector3(60f, 10f), 7f, Color.green, Color.grey, 100f,
                0.4f);
        }

        public void DecreaseHealth(int decrease)
        {
            health -= decrease;
            if (health <= 0)
            {
                Destroy(this.gameObject);
                return;
            }

            _bar.SetSize(health);
        }

        public void IncreaseHealth(int increase)
        {
            health += increase;
            if (health > 100)
                health = 100;
            _bar.SetSize(health);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_death)
            {
                CreateDeathLoot();
                Destroy(gameObject);
                return;
            }
            if (other.GetComponent<DamageComponent>() == null)
                return;

            if (other.GetComponent<DamageComponent>().originID == this.originID)
                return;
            health -= other.gameObject.GetComponent<DamageComponent>().damage;
            _bar.SetSize(health / 100f);
            if (health > 0)
                return;
            _death = true;
            _animator.Play("Death_left");
            CreateDeathLoot();
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        public void CreateDeathLoot()
        {
            string objectTag = gameObject.tag;
            Destroy(_bar.gameObject);
            Debug.Log("Someone is dead: " + tag);
            switch (objectTag)
            {
                case "Cow":
                {
                    Debug.Log("Health component dead cow");
                    gameObject.GetComponent<UnitDeath>().AfterDeath();
                    break;
                }
            }
        }
        
    //data members
        public int health;
        public bool isPlayer = false;
        public int originID;
        
        private HealthBar _bar;
        private Animator _animator;
        private bool _death;
    }
}//end of namespace HealthFight