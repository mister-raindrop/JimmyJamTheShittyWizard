using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerSingleton : MonoBehaviour {
    private static GameManagerSingleton _instance;

    public static GameManagerSingleton Instance {
        get {
            if (_instance == null) {
                GameObject g = new GameObject("GameManager");
                g.AddComponent<GameManagerSingleton>();
            }
            return _instance;
        }
    }

    public int enemiesKilled = 0;
    public GameObject[] towers;
    public GameObject[] originalTowers;
    public float fadeOutTime = 5f;
    private HealthControl hc;
    private CameraFOV cam;
    private TextMeshProUGUI notification;
    private bool soulnot1 = false, soulnot2 = false, soulnot3 = false;
    private GameObject helpText;

    private void Awake() {
        _instance = this;
        
        originalTowers = towers;
        hc = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthControl>();
        cam = Camera.main.gameObject.GetComponent<CameraFOV>();
        notification = GameObject.FindGameObjectWithTag("Notification").GetComponent<TextMeshProUGUI> ();
        notification.color = Color.clear;
    }

    private void Start() {
        Cursor.visible = false;
        //helpText.SetActive(true);
        Time.timeScale = 0;
        
    }

    private void Update() {
        if (towers.Length == 3 && !soulnot1) {
            notification.text = "A new Soul is being hosted at the Lamp of Fear.";
            StartCoroutine(NotificationFade(Color.white));
            soulnot1 = true;
            StartCoroutine(WaitPointlessly(4));
        }

        if (towers.Length == 2 && !soulnot2) {
            notification.text = "The Soul is now being purified by The Lamp of Guilt.";
            StartCoroutine(NotificationFade(Color.white));
            soulnot2 = true;
            StartCoroutine(WaitPointlessly(4));
        }

        if (towers.Length == 1 && !soulnot3) {
            notification.text = "The Soul has moved on to the Lamp of Redemption.";
            StartCoroutine(NotificationFade(Color.white));
            soulnot3 = true;
            StartCoroutine(WaitPointlessly(4));
        }

        if (towers.Length < 1 && !hc.playerDead) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Controls>().enabled = false;
            cam.FOVset(120);
            StartCoroutine(LoadNextLevel());
            //SceneManager.LoadSceneAsync("GameOver");
        }

        
    }

    IEnumerator LoadNextLevel() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("GameOver");
    }

    IEnumerator NotificationFade(Color col) {
        Debug.Log("Notification");
        yield return new WaitForSeconds(1f);
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime) {
            notification.color = Color.Lerp(notification.color, col, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }

    }


    IEnumerator WaitPointlessly(float secs) {
        yield return new WaitForSeconds(secs);
        StartCoroutine(NotificationFade(Color.clear));
    }


    


}
