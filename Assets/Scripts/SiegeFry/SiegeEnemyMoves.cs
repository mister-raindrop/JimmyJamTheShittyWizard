using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SiegeEnemyMoves : MonoBehaviour {

    GameObject tower;
    NavMeshAgent nav;
    Animator anim;

    private void Awake() {
        tower = GameObject.FindGameObjectWithTag("Tower").gameObject;
        nav = GetComponent<NavMeshAgent>();
        nav.speed = Random.Range(3.0f, 4.0f);
        anim = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
       if (!anim.GetBool("EnemyAttack") && tower.GetComponent<TowerStuff>().currentHealth > 0 && !GetComponent<SiegeHealthControl>().isDead) {
            transform.LookAt(tower.transform);
            nav.SetDestination(tower.transform.position);
        }
	}
}
