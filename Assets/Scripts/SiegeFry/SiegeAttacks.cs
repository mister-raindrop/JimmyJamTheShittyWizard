using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SiegeAttacks : MonoBehaviour {

    public GameObject AttackBox;
    Animator anim;
    NavMeshAgent nav;
    GameObject tower;
    bool towerDead;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        tower = GameObject.FindGameObjectWithTag("Tower").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (tower.GetComponent<TowerStuff>().currentHealth <= 0 && !towerDead) {
            anim.SetBool("EnemyAttack", false);
            anim.SetTrigger("PlayerDeath");
            towerDead = true;
        }
	}

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Tower") && tower.GetComponent<TowerStuff>().currentHealth > 0) {
            anim.SetBool("EnemyAttack", true);
            nav.enabled = false;
        }
    }

    private void OnTriggerExit (Collider collision) {
        if (collision.gameObject.CompareTag("Tower")) {
            anim.SetBool("EnemyAttack", false);
            nav.enabled = true;
        }
    }

    void AttackColliderOn() {
        //coll.enabled = true;
        AttackBox.GetComponent<BoxCollider>().enabled = true;
        //Debug.Log("On");
    }

    void AttackColliderOff() {
        //coll.enabled = false;
        AttackBox.GetComponent<BoxCollider>().enabled = false;
        //tower.GetComponent<Animator>().SetBool("Stagger", false);

        //Debug.Log("Off");
    }
}
