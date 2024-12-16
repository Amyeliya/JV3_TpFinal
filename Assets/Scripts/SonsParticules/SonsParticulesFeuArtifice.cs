using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonsParticulesFeuArtifice : MonoBehaviour
{
    [SerializeField] private AudioClip _departFeuArtifice;
    private AudioSource _audioFeuArtifice; 

    private void Start() {
        AudioSource.PlayClipAtPoint(_departFeuArtifice, transform.position);
    }
}
