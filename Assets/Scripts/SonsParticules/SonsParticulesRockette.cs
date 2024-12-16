using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonsParticulesRockette : MonoBehaviour
{
    [SerializeField] private AudioClip _departRocket;
    private AudioSource _audioRocket; 

    private void Start() {
        AudioSource.PlayClipAtPoint(_departRocket, transform.position);
    }
}
