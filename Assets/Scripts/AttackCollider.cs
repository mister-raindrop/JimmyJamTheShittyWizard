using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {

    GameObject player;
    BoxCollider coll;
    Animator playerAnim;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        coll = GetComponent<BoxCollider>();
        playerAnim = player.GetComponent<Animator>();
        coll.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("hit");
            playerAnim.SetBool("Stagger", true);
            player.gameObject.GetComponents<AudioSource>()[2].Play();
            Camera.main.gameObject.GetComponent<CameraShake>().shakeDuration = 0.4f;
            player.GetComponent<HealthControl>().PlayerDamaged(20);
            Debug.Log("Current Health: " + player.GetComponent<HealthControl>().currentHealth);
        }
        
    }


    
}
