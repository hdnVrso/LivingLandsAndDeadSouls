using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace HealthFight
{
    public class DamageComponent : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            damageCollider = this.gameObject.AddComponent<CircleCollider2D>();
            damageCollider.isTrigger = true;
            damageCollider.radius = damageRadius;
        }
        
        //data members
        public int damage;
        public float damageRadius;
        public int originID;
        public CircleCollider2D damageCollider;
    }
}//end of namespace HealthFight