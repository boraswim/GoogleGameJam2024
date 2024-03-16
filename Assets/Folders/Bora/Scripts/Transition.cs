using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera transitionCam;
    void OnTriggerEnter(Collider other)
    {
        transitionCam.Priority = 15;
    }

    void OnTriggerExit(Collider other)
    {
        transitionCam.Priority = 5;
    }
}
