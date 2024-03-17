using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(DealDamage(other.gameObject, bulletDamage));
        }
    }

    IEnumerator DealDamage(GameObject enemy, int bulletDamage)
    {
        enemy.GetComponent<SkeletonAI>().SkeletonHp-=bulletDamage;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
