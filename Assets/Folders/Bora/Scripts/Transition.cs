using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera transitionCam;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            transitionCam.Priority = 15;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            transitionCam.Priority = 5;
    }
}
