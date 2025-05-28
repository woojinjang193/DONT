using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Pool;

public class PooledObject : MonoBehaviour
{
    public ObjectPool returnPool;
    [SerializeField] float returnTime;
    private float timer;

    private void Start()
    {

    }
    private void OnEnable()
    {
        timer = returnTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ReturnPool();
        }
    }


    public void ReturnPool()
    {
        if (returnPool == null)
        {
            Destroy(gameObject);
        }
        else
        {
            returnPool.ReturnPool(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            return;
        }

        else
        {
            ReturnPool();
            AudioManager.instance.PlaySfx(AudioManager.Sfx.BulletHit);
        }
            
        


       
    }

}
