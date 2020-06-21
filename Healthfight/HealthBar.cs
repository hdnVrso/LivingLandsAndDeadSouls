using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthFight
{
    public class HealthBar : MonoBehaviour
    {
        void Start()
        {
            _bar = transform.Find("Bar");
            if (isPlayer)
                return;
            _bar.localScale = new Vector3(initialHealth / 100, 1);
        }

        public static HealthBar Create(Transform position, Vector3 size, float borderThickness, Color barColor, 
            Color backgroundColor, float initialHealth, float distanceY)
        {
            //Main health bar
            var healthBarGameObject = new GameObject("HealthBar");
            //healthBarGameObject.transform.position = position.position;
            healthBarGameObject.transform.SetParent(position);
            healthBarGameObject.transform.localPosition = new Vector2(0f, distanceY);

            //Border
            var borderGameObject = new GameObject("Border", typeof(SpriteRenderer));
            borderGameObject.transform.SetParent(healthBarGameObject.transform);

            borderGameObject.transform.localPosition = Vector3.zero;
            borderGameObject.transform.localScale = size + Vector3.one * borderThickness;
            borderGameObject.GetComponent<SpriteRenderer>().color = Color.black;
            borderGameObject.GetComponent<SpriteRenderer>().sprite =
                UnityEngine.Resources.Load<Sprite>("Sprites/Objects/WhitePixel");
            borderGameObject.GetComponent<SpriteRenderer>().sortingOrder = 90;

            //Background
            var backgroundGameObject = new GameObject("Background", typeof(SpriteRenderer));
            backgroundGameObject.transform.SetParent(healthBarGameObject.transform);
            backgroundGameObject.transform.localPosition = Vector3.zero;
            backgroundGameObject.transform.localScale = size;
            backgroundGameObject.GetComponent<SpriteRenderer>().color = backgroundColor;
            backgroundGameObject.GetComponent<SpriteRenderer>().sprite =
                UnityEngine.Resources.Load<Sprite>("Sprites/Objects/WhitePixel");
            backgroundGameObject.GetComponent<SpriteRenderer>().sortingOrder = 100;

            //Bar
            var barGameObject = new GameObject("Bar");
            barGameObject.transform.SetParent(healthBarGameObject.transform);
            barGameObject.transform.localPosition = new Vector3(-size.x*0.01f/2f, 0f);
            barGameObject.transform.localScale = new Vector3(1, 1);

            //Bar sprite
            var barSpriteGameObject = new GameObject("BarSprite", typeof(SpriteRenderer));
            barSpriteGameObject.transform.SetParent(barGameObject.transform);
            barSpriteGameObject.transform.localPosition = new Vector3(size.x*0.01f/2f, 0f);////
            barSpriteGameObject.transform.localScale = size;
            barSpriteGameObject.GetComponent<SpriteRenderer>().color = barColor;
            barSpriteGameObject.GetComponent<SpriteRenderer>().sprite =
                UnityEngine.Resources.Load<Sprite>("Sprites/Objects/WhitePixel");
            barSpriteGameObject.GetComponent<SpriteRenderer>().sortingOrder = 110;

            HealthBar healthBar = healthBarGameObject.AddComponent<HealthBar>();
            healthBar.initialHealth = initialHealth;
            healthBar._bar = barGameObject.transform;
            return healthBar;
        }

        public void SetSize(float sizeNormalized)
        {
            if (isPlayer == true)
            {
                sizeNormalized *= 1000;
            }
            _bar.localScale = new Vector3(sizeNormalized, 1f);
        }
        
        //data members
        public float initialHealth;
        public bool isPlayer;
        
        private Transform _bar;
    }
}// end of namespace HealthFight