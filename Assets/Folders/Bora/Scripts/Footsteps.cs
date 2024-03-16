using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public AudioClip[] FootstepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;
    private float stepInterval = 0.5f;
    [SerializeField] Transform _player;
    [SerializeField] private StarterAssetsInputs _starterAssetsInputs;

    void Start()
    {
        StartCoroutine("Footsteps"); 
    }

    IEnumerator Footsteps()
    {
        yield return new WaitUntil(() => _starterAssetsInputs.move.x != 0 || _starterAssetsInputs.move.y != 0);
        if(_starterAssetsInputs.sprint)
            stepInterval = 0.3f;
        else
            stepInterval = 0.5f;
        var index = Random.Range(0, FootstepAudioClips.Length);
        AudioSource.PlayClipAtPoint(FootstepAudioClips[index], _player.position, FootstepAudioVolume);
        yield return new WaitForSeconds(stepInterval);
        StartCoroutine("Footsteps");
    }
}
