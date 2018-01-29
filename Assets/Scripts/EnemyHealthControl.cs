using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealthControl : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    private Animator anim;
    private AudioSource audioClip;

    public bool isDead;
    // Use this for initialization
    void Start() {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        audioClip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }


    public void EnemyDamaged(int dmg) {
        Debug.Log("damaged");
        currentHealth -= dmg;
        if (currentHealth <= 0 && !isDead) {
            isDead = true;
            GameManagerSingleton.Instance.enemiesKilled++;
            anim.SetTrigger("EnemyDead");
            audioClip.Play();
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
            foreach (Collider c in GetComponents<Collider>()) {
                c.enabled = false;
            }
            Destroy(gameObject, 3f);

        }
    }
}
