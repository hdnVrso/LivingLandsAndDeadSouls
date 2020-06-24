using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace HealthFight
{
    public class Bullet : MonoBehaviour
    {
        public static GameObject Create(Transform parentTransform, int direction, float speed, int damage, 
            float damageRadius_, int originID)
        {
            var bulletGameObject = new GameObject("Bullet");
            var bulletSpriteRenderer = bulletGameObject.AddComponent<SpriteRenderer>();

            bulletSpriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/Objects/bullet");

            bulletSpriteRenderer.sortingOrder = 90;
            var dmgCmp = bulletGameObject.AddComponent<DamageComponent>();
            dmgCmp.damage = damage;
            dmgCmp.originID = originID;
            dmgCmp.damageRadius = damageRadius_;
                
            var myRigidBody = bulletGameObject.AddComponent<Rigidbody2D>();
            myRigidBody.gravityScale = 0;
            switch (direction)
            {
                case 0:
                    myRigidBody.velocity = new Vector2(0f, -speed);
                    bulletGameObject.transform.position = parentTransform.transform.position + new Vector3(0, -0.1f, 0);
                    break;
                case 1:
                    myRigidBody.velocity = new Vector2(0f, speed);
                    bulletGameObject.transform.position = parentTransform.transform.position + new Vector3(0, 0.1f, 0);
                    break;
                case 2:
                    myRigidBody.velocity = new Vector2(speed, 0f);
                    bulletGameObject.transform.position = parentTransform.transform.position + new Vector3(0.5f, 0.1f, 0);
                    break;
                case 3:
                    myRigidBody.velocity = new Vector2(-speed, 0f);
                    bulletGameObject.transform.position = parentTransform.transform.position + new Vector3(-0.5f, 0.1f, 0);
                    break;
            }
            myRigidBody.mass = 0;
            myRigidBody.freezeRotation = true;
            bulletGameObject.AddComponent<Bullet>();
            bulletGameObject.transform.Rotate(new Vector3(0, 0, 1), 90);
            bulletGameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            
            return bulletGameObject;
        }
        
        public static GameObject CreateFromBandit(Transform parentTransform, Transform targetPosition, 
            float speed, int damage, float damageRadius_, int originID)
        {
            var bulletGameObject = new GameObject("Bullet");
            var bulletSpriteRenderer = bulletGameObject.AddComponent<SpriteRenderer>();

            bulletSpriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/Objects/bullet");

            bulletSpriteRenderer.sortingOrder = 90;
            var dmgCmp = bulletGameObject.AddComponent<DamageComponent>();
            dmgCmp.damage = damage;
            dmgCmp.originID = originID;
            dmgCmp.damageRadius = damageRadius_;
                
            var myRigidBody = bulletGameObject.AddComponent<Rigidbody2D>();
            myRigidBody.gravityScale = 0;
            bulletGameObject.transform.position = parentTransform.transform.position + new Vector3(0, -0.1f, 0);
            bulletGameObject.transform.position = Vector2.MoveTowards(bulletGameObject.transform.position, targetPosition.position, speed * Time.deltaTime);
               
            myRigidBody.mass = 0;
            myRigidBody.freezeRotation = true;
            bulletGameObject.AddComponent<Bullet>();
            bulletGameObject.transform.Rotate(new Vector3(0, 0, 1), 90);
            bulletGameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            return bulletGameObject;
        }

        void Start()
        {
            ttl = 1000;
        }

        void Update()
        {
            --ttl;
            if (ttl <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == "Bullet" || other.GetComponent<HealthComponent>() == null || other.GetComponent<HealthComponent>().originID == this.GetComponent<DamageComponent>().originID) return;
            Destroy(this.gameObject);
        }
        
        //data members
        public int ttl;
    }
}//end of namespace HealthFight