using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    private static int pagesCollected = 0;
    void Start()
    {
        StartCoroutine("CheckPages");
        DontDestroyOnLoad(this);
    }

    public static void AddPage()
    {
        pagesCollected++;
    }

    IEnumerator CheckPages()
    {
        yield return new WaitUntil(() => pagesCollected == 3);
        GameObject.Find("Map").SetActive(true);
        Debug.Log("All pages collected");
    }
}
