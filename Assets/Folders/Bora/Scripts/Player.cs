using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int playerHP = 30;
    public float attackInterval = 1f;
    public float bulletSpeed = 5f;
    [SerializeField] Slider HpBar;
    [SerializeField] private GameObject bullet;
    

    void Start()
    {
        if(HpBar is not null)
            HpBar.value = playerHP;
        StartCoroutine("ShootBullets");
    }


    public void PlayerHit(int hitValue)
    {
        playerHP-=hitValue;
        Debug.Log(playerHP);
        if(HpBar is not null)
            HpBar.value = Mathf.Lerp(HpBar.value, playerHP, 3);
        if(playerHP <= 0)
            Debug.Log("Game Over");
    }

    IEnumerator ShootBullets()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
        Rigidbody rbBullet = Instantiate(bullet, transform.GetChild(0).transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rbBullet.AddForce(transform.forward * bulletSpeed * 15f, ForceMode.Impulse);
        rbBullet.AddForce(transform.up * bulletSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(attackInterval);
        StartCoroutine("ShootBullets");
    }
}
