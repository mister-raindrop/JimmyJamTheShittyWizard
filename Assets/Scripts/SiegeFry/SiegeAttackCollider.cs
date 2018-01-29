using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiegeAttackCollider : MonoBehaviour {

    GameObject tower;
    BoxCollider coll;
    //Animator playerAnim;
	// Use this for initialization
	void Start () {
        tower = GameObject.FindGameObjectWithTag("Tower").gameObject;
        coll = GetComponent<BoxCollider>();
        //playerAnim = tower.GetComponent<Animator>();
        coll.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Tower")) {
            Debug.Log("hit");
            tower.GetComponentInParent<AudioSource>().Play();
            //playerAnim.SetBool("Stagger", true);
            tower.GetComponent<TowerStuff>().TowerDamaged(100);
            //Debug.Log("Current Health: " + player.GetComponent<HealthControl>().currentHealth);
        }
        
    }


    
}
