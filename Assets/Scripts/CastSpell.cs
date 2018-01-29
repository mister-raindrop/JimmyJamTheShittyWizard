using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour {

    public float spellForce = 20f;
    public Transform spellHolder;
    public GameObject spellPrefab;
    public float rayPoint = 20.0f;

    Ray ray;
    Vector3 spellDir;
    GameObject spellInstance;
    Rigidbody spellRb;
    ParticleSystem[] spellSystem;
    AudioSource spellSound;
    // Use this for initialization
    void Start() {
        spellSound = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update() {

    }

    void FireSpell() {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        spellDir = (ray.GetPoint(rayPoint) - spellHolder.position).normalized;
        //Debug.DrawRay(ray.origin, spellDir, Color.red, 60, false);

        spellInstance = Instantiate(spellPrefab, spellHolder.position, Quaternion.identity);

        spellInstance.transform.LookAt(ray.GetPoint(rayPoint)); // make sure it's facing the crosshair location

        spellRb = spellInstance.GetComponent<Rigidbody>();
        spellRb.AddForce(spellDir * spellForce, ForceMode.Impulse);

        //spellSystem = spellInstance.GetComponentInChildren(typeof(ParticleSystem), true) as ParticleSystem;
        spellSystem = spellInstance.GetComponentsInChildren<ParticleSystem>();
        //spellSystem.transform.LookAt(ray.GetPoint(100000.0f));
        //spellSystem.Play(true);
        foreach (ParticleSystem ps in spellSystem) {
            ps.Play();
        }
        spellSound.Play();
        Destroy(spellInstance, 5);
    }
}
