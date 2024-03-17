using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PagePickup : MonoBehaviour
{
    private bool playerInRange = false;
    public int sceneIndex = 0;
    [SerializeField] private GameObject picture;

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
        Library.AddPage();
        picture.SetActive(true);
        Debug.Log("Pickup");
        yield return new WaitForSeconds(4f);
        if(sceneIndex != 9)
            SceneManager.LoadScene(sceneIndex);
        StartCoroutine("PickupCheck");
    }
}