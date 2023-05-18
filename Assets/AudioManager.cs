using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "white" && collision.gameObject.name == "black")
        {
            audioSource.PlayOneShot(audioClipArray[0]);
        }

        if(Input.GetMouseButtonUp(0))
        {
            audioSource.PlayOneShot(audioClipArray[1]);
        }

        if(collision.gameObject.name == "Queen" || collision.gameObject.name == "white" || collision.gameObject.name == "black")
        {
            audioSource.PlayOneShot(audioClipArray[2]);
        }
    }
}
