using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrailTween : MonoBehaviour {

    public string pathName;
    public float time;
    // Use this for initialization
    void Start() {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "easeType", iTween.EaseType.easeInOutSine, "time", time));
    }
}
	