using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ForgePass : MonoBehaviour
{
    private bool playerInRange = false;
    [SerializeField] private TMP_InputField passField;
    [SerializeField] private GameObject passButton;

    void Start()
    {
        StartCoroutine("PassCheck");
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

    IEnumerator PassCheck()
    {
        yield return new WaitUntil(() => playerInRange && Input.GetKeyDown(KeyCode.F));
        passField.gameObject.SetActive(true);
        passButton.SetActive(true);
        Debug.Log("Pickup");
        yield return new WaitUntil(() => !playerInRange);
        passField.gameObject.SetActive(false);
        passButton.SetActive(false);
        StartCoroutine("PassCheck");
    }

    public void SubmitPass()
    {
        if(passField.text == "825")
            SceneManager.LoadScene(3);
    }
}