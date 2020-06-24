using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace HealthFight
{
    public class HealthComponent : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
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
        }

        private void CreateHealthBar()
        {
            _bar = HealthBar.Create(this.gameObject.transform, new Vector3(60f, 10f), 7f, Color.green, Color.grey, 100f, 0.4f);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<DamageComponent>() == null)
                return;

            if (other.GetComponent<DamageComponent>().originID == this.originID)
                return;
            health -= other.gameObject.GetComponent<DamageComponent>().damage;
            _bar.SetSize(health/100f);
            if (health > 0)
                return;
            //_animator.Play("Death");
            Destroy(_bar.gameObject);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        
        //data members
        public int health;
        public bool isPlayer = false;
        public int originID;
        
        private HealthBar _bar;
        private Animator _animator;
    }
}//end of namespace HealthFight