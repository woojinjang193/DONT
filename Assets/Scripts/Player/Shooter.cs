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
 
    [Range(10, 30)]
    [SerializeField] float bulletSpeed;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    public void Fire() 
    {
        Transform muzzle = spriteRenderer.flipX ? muzzlePointLeft : muzzlePointRight;
        //<결과를 저장할 변수> = <조건> ? <조건이 True일때> : <조건이 False일때>;

        PooledObject instance = bulletPool.GetPool(muzzle.position, muzzle.rotation);
        Rigidbody2D bulletRigibody = instance.GetComponent<Rigidbody2D>();
        bulletRigibody.velocity = muzzle.right * bulletSpeed;

    }
         
    }       



