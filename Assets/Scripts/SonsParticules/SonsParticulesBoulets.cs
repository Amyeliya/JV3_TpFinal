using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonsParticulesBoulets : MonoBehaviour
{

    [SerializeField] private AudioClip _explosionBoulet;
    private AudioSource _audioBoulet; 

    private void Start() {
        AudioSource.PlayClipAtPoint(_explosionBoulet, transform.position);
    }


}
