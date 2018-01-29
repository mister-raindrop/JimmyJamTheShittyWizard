using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TowerStuff : MonoBehaviour {
    public int maxHealth = 700;
    public int currentHealth = 700;
    public Slider towerHPSlider;

    private Animator anim;
    private Controls controls;
    bool towerDead;
    CameraFOV cam;

    // Use this for initialization
    void Start() {
        currentHealth = maxHealth;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        controls = GameObject.FindGameObjectWithTag("Player").GetComponent<Controls>();
        cam = Camera.main.gameObject.GetComponent<CameraFOV>();
    }

    // Update is called once per frame
    void Update() {
    }

    public void TowerDamaged(int dmg) {
        currentHealth -= dmg;

        towerHPSlider.value = currentHealth;
        if (currentHealth <= 0 && !towerDead) {
            towerDead = true;
            anim.SetTrigger("PlayerDead");
            //gameObject.GetComponent<Rigidbody>().useGravity = true;
            controls.enabled = false;
            //Camera.main.transform.localRotation = Quaternion.Slerp(Camera.main.transform.localRotation, Quaternion.LookRotation(gameObject.transform.position - Camera.main.transform.position), 0.1f);
            cam.FOVset(120);
            StartCoroutine(LoadNextLevel());
            //SceneManager.LoadSceneAsync("GameOver");

        }
    }

    IEnumerator LoadNextLevel() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync("GameOver");
    }
}
