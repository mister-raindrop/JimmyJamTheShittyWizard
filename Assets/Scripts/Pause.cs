using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour {

    TextMeshProUGUI textComp;
    // Use this for initialization
    void Start () {
        textComp = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H)) {
            if (Time.timeScale == 1) {
                textComp.enabled = true;

                Time.timeScale = 0;
            } else {
                textComp.enabled = false;
                Time.timeScale = 1;

            }
        }
    }
}
