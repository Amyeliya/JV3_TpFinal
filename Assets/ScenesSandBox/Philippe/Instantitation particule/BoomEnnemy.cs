using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEnnemy : MonoBehaviour
{

    [SerializeField] private GameObject _boom;
    [SerializeField] private AudioClip _soundClip;  
    private AudioSource _audioSource; 

    [SerializeField] private AudioClip _soundBoom;  
    private AudioSource _audioBoom; 


private void OnDestroy()
{

    Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);


    GameObject BoomInstance = Instantiate(_boom, transform.position, rotation);


    Destroy(BoomInstance, 5f);
}
    private void OnCollisionEnter(Collision other)
    {

    if(other.gameObject.tag == "Ally" ){

            Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);

            GameObject BoomInstance = Instantiate(_boom, transform.position, rotation); /*== Pour faire confetti == */

            AudioSource.PlayClipAtPoint(_soundClip, transform.position);

            AudioSource.PlayClipAtPoint(_soundBoom, transform.position);

            Destroy(BoomInstance, 5f);

            Destroy(gameObject);
        }
    
    }
}
