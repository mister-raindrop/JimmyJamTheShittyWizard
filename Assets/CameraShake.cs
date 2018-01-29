using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float shakeDuration = 0.0f;
    public float shakeAmount = 0.7f;
    public float smoothing = 0.5f;

    Vector3 startPos;
	// Use this for initialization
	void Start () {
        startPos = Camera.main.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (shakeDuration > 0) {
            Camera.main.transform.localPosition = startPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * smoothing;
        } else {
            shakeDuration = 0f;
            Camera.main.transform.localPosition = startPos;
        }
	}
}
