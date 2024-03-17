using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] GameObject DialogueBox;
    [SerializeField] CinemachineVirtualCamera transitionCam;
    bool playerInRange;

    void Start()
    {
        StartCoroutine("DialogueCheck");
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            playerInRange = false;
    }

    IEnumerator DialogueCheck()
    {
        yield return new WaitUntil(() => playerInRange && Input.GetKeyDown(KeyCode.F));
        transitionCam.Priority = 15;
        DialogueBox.SetActive(true);
        yield return new WaitUntil(() => !playerInRange);
        transitionCam.Priority = 5;
        DialogueBox.SetActive(false);
        StartCoroutine("DialogueCheck");
    }
}
