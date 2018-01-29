using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthControl : MonoBehaviour {
    public int maxHealth = 200;
    public int currentHealth;
    public Slider hpSlider;

    private Animator anim;
    private Controls controls;
    public bool playerDead;
    CameraFOV cam;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        controls = GetComponent<Controls>();
        cam = Camera.main.gameObject.GetComponent<CameraFOV>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerDamaged (int dmg) {
        currentHealth -= dmg;
        
        hpSlider.value = currentHealth;
        if (currentHealth <= 0 && !playerDead) {
            playerDead = true;
            anim.SetTrigger("PlayerDead");
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            controls.enabled = false;
            Camera.main.transform.localRotation = Quaternion.Slerp(Camera.main.transform.localRotation, Quaternion.LookRotation(gameObject.transform.position - Camera.main.transform.position), 0.1f);
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
