using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoves : MonoBehaviour {

    GameObject player;
    NavMeshAgent nav;
    Animator anim;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        nav = GetComponent<NavMeshAgent>();
        nav.speed = Random.Range(2.0f, 3.5f);
        anim = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
       if (!anim.GetBool("EnemyAttack") && player.GetComponent<HealthControl>().currentHealth > 0 && !GetComponent<EnemyHealthControl>().isDead) {
            transform.LookAt(player.transform);
            nav.SetDestination(player.transform.position);
        }
	}
}
