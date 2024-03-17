using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagePickup : MonoBehaviour
{
    [SerializeField] private GameObject page;
    private bool playerInRange = false;

    void Start()
    {
        StartCoroutine("PickupCheck");
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        } 
    }

    IEnumerator PickupCheck()
    {
        yield return new WaitUntil(() => playerInRange && Input.GetKeyDown(KeyCode.F));
        page.SetActive(true);
        Library.AddPage();
        Debug.Log("Pickup");
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("PickupCheck");
    }
}
