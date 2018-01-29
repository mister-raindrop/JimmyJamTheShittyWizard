using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttacks : MonoBehaviour {

    public GameObject AttackBox;
    Animator anim;
    NavMeshAgent nav;
    GameObject player;
    bool playerDead;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<HealthControl>().currentHealth <= 0 && !playerDead) {
            anim.SetBool("EnemyAttack", false);
            anim.SetTrigger("PlayerDeath");
            playerDead = true;
        }
	}

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player") && player.GetComponent<HealthControl>().currentHealth > 0) {
            anim.SetBool("EnemyAttack", true);
            nav.enabled = false;
        }
    }

    private void OnTriggerExit (Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            anim.SetBool("EnemyAttack", false);
            nav.enabled = true;
        }
    }

    void AttackColliderOn() {
        //coll.enabled = true;
        AttackBox.GetComponent<BoxCollider>().enabled = true;
        Debug.Log("On");
    }

    void AttackColliderOff() {
        //coll.enabled = false;
        AttackBox.GetComponent<BoxCollider>().enabled = false;
        player.GetComponent<Animator>().SetBool("Stagger", false);

        Debug.Log("Off");
    }
}
