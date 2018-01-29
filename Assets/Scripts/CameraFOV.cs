using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOV : MonoBehaviour {

    private float defaultFOV = 60f;
    private float currentFOV;
    // Use this for initialization
    void Start() {
        currentFOV = defaultFOV;
    }

    // Update is called once per frame
    void Update() {

    }

    private void LateUpdate() {
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            FOVreset();
        }
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, currentFOV, 0.1f);
    }


    public void FOVreset() {
        currentFOV = defaultFOV;
    }

    public void FOVset(float fov) {
        currentFOV = fov;
    }


}
