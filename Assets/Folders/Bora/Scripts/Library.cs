using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    public int pagesCollected = 0;
    void Start()
    {
        StartCoroutine("CheckPages");
    }

    IEnumerator CheckPages()
    {
        yield return new WaitUntil(() => pagesCollected == 3);
        Debug.Log("All pages collected");
    }
}
