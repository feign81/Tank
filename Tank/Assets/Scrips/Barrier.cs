﻿using UnityEngine;

///<summary>
///
///<summary>

public class Barrier : MonoBehaviour
{
    public AudioClip hitAudio;

    public void PlayAudio()
    {
        AudioSource.PlayClipAtPoint(hitAudio, transform.position);
    }
}
