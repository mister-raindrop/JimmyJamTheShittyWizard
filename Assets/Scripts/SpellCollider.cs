using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollider : MonoBehaviour {

    private EnemyHealthControl enemyHpComp;
    private SiegeHealthControl siegeHpComp;
    public GameObject hitPrefab;
    bool isColliding;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
       isColliding = false;
    }

    /*private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {

            enemyHpComp = other.gameObject.GetComponent<EnemyHealthControl>();

            if (enemyHpComp.currentHealth > 0) {
                Debug.Log("hit");
                enemyHpComp.EnemyDamaged(100);
            }
            Destroy(gameObject);
        }

    }*/


    /*private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            enemyHpComp = collision.gameObject.GetComponent<EnemyHealthControl>();
            if (enemyHpComp.currentHealth > 0) {
                Debug.Log("Hit Enemy");
                enemyHpComp.EnemyDamaged(100);
                Camera.main.gameObject.GetComponent<CameraShake>().shakeDuration = 0.3f;

            }
        }

        if (collision.gameObject.CompareTag("Siege")) {
            siegeHpComp = collision.gameObject.GetComponent<SiegeHealthControl>();
            if (siegeHpComp.currentHealth > 0) {
                Debug.Log("Hit Enemy");
                siegeHpComp.EnemyDamaged(100);
                Camera.main.gameObject.GetComponent<CameraShake>().shakeDuration = 0.3f;

            }
        }

        if (!collision.gameObject.CompareTag("Player")) {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            GameObject t = Instantiate(hitPrefab, pos, rot);
            Destroy(t, 3f);
            Destroy(gameObject);
            
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }*/

    private void OnTriggerEnter(Collider collision) {
        if (isColliding) { return;  }
        isColliding = true;
        if (collision.gameObject.CompareTag("Enemy")) {
            enemyHpComp = collision.gameObject.GetComponent<EnemyHealthControl>();
            if (enemyHpComp.currentHealth > 0) {
                Debug.Log("Hit Enemy");
                enemyHpComp.EnemyDamaged(100);
                Camera.main.gameObject.GetComponent<CameraShake>().shakeDuration = 0.3f;

            }
        }

        if (collision.gameObject.CompareTag("Siege")) {
            siegeHpComp = collision.gameObject.GetComponent<SiegeHealthControl>();
            if (siegeHpComp.currentHealth > 0) {
                Debug.Log("Hit Enemy");
                siegeHpComp.EnemyDamaged(100);
                Camera.main.gameObject.GetComponent<CameraShake>().shakeDuration = 0.3f;

            }
        }


        if (!collision.gameObject.CompareTag("Player")) {
            GameObject t = Instantiate(hitPrefab, transform.position, transform.rotation);
            Destroy(t, 3f);
           
            
        }

        
    }

    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        
        Destroy(gameObject, 2f);
    }

}
