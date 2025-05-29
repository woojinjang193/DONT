using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    [SerializeField] private GameObject carrotFragments;

    public void ParticalOn()
    {
        Instantiate(carrotFragments, transform.position, Quaternion.identity);
    }
}
