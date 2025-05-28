using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletpre;
    [SerializeField] Transform muzzlePointRight;
    [SerializeField] Transform muzzlePointLeft;
    [SerializeField] ObjectPool bulletPool;
    [SerializeField] float fireDelay;

    [Range(10, 30)]
    [SerializeField] float bulletSpeed;

    private SpriteRenderer spriteRenderer;

    private float lastFireTime = 0;
    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    public void Fire() 
    {
        
        if (Time.time - lastFireTime < fireDelay)
        {
            return;
        }
        lastFireTime = Time.time;

        Transform muzzle = spriteRenderer.flipX ? muzzlePointLeft : muzzlePointRight;
        //<����� ������ ����> = <����> ? <������ True�϶�> : <������ False�϶�>;

        PooledObject instance = bulletPool.GetPool(muzzle.position, muzzle.rotation);
        Rigidbody2D bulletRigibody = instance.GetComponent<Rigidbody2D>();
        bulletRigibody.velocity = muzzle.right * bulletSpeed;

    }

  // public void Fire(float speed)
  // {
  //     if (Time.time - lastFireTime < fireDelay)
  //     {
  //         return;
  //     }
  //     lastFireTime = Time.time;
  //
  //
  //     PooledObject instance = bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
  //     Rigidbody2D bulletRigibody = instance.GetComponent<Rigidbody2D>();
  //     bulletRigibody.velocity = muzzlePoint.right * speed;
  //
  // }

    
    }       



