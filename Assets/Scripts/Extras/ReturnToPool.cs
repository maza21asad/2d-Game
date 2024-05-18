﻿
//updated
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LayerMask objectMask;
    [SerializeField] private float lifeTime = 2f;

    [Header("Effects")]
    [SerializeField] private ParticleSystem impactPS;

private Projectile projectile;
private BossProjectile bossProjectile;    

    private void Start()
    {
        projectile = GetComponent<Projectile>();
        bossProjectile = GetComponent<BossProjectile>();
    }

    // Returns this object to the pool
    private void Return()
    {
        if (projectile != null)
        {
            projectile.ResetProjectile();
        }  
      
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckLayer(other.gameObject.layer, objectMask))
        {
            if (projectile != null)
            {
//                projectile.DisableProjectile();
            }

            if (bossProjectile != null)
            {
                bossProjectile.DisableBossProjectile();
            }

            impactPS.Play();
            Invoke(nameof(Return), impactPS.main.duration);
        }
    }

    private bool CheckLayer(int layer, LayerMask objectMask)
    {
        return ((1 << layer) & objectMask) != 0;
    }
    
    private void OnEnable()
    {
        if (lifeTime > 0)
        {
            Invoke(nameof(Return), lifeTime);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}


/*
// 4(6)
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    [Header("Settings")]
[SerializeField] private float lifeTime = 2f;

    private Projectile projectile;    

    private void Start()
    {
        projectile = GetComponent<Projectile>();
    }

    // Returns this object to the pool
    private void Return()
{
        if (projectile != null)
        {
            projectile.ResetProjectile();
        }  
      
        gameObject.SetActive(false);
    }
    
    private void OnEnable()
    {
        Invoke(nameof(Return), lifeTime);       
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
*/