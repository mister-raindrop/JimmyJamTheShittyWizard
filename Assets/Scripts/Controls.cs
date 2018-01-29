using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controls : MonoBehaviour {
    public float walkSpeed = 2.0f;
    public float runSpeed = 4.0f;
    public float sprintSpeed = 6.0f;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public float speedDamping = 0.01f;
    public float backSpeed = 1.0f;
    public float strafeSpeed = 0.6f;

    private Animator anim;
    private Rigidbody rBody;
    private float mouseH, mouseV;
    private float moveSpeed;
    private Vector2 smoothVec, mouseLook, mouseInput;
    private bool sprint;
    private float speedThreshold;
    private int animSpeedFloat;
    private bool forwardPressed, backwardPressed;
    private float animHFloat;
    private Ray ray;
    private Vector3 lookDir;
    private float keyboardH;
    private bool castSpell;
    private CameraFOV camfov;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
        animSpeedFloat = Animator.StringToHash("Speed");
        animHFloat = Animator.StringToHash("horizontalMouseV");
        camfov = Camera.main.gameObject.GetComponent<CameraFOV>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        
        mouseH = Input.GetAxisRaw("Mouse X");
        mouseV = Input.GetAxisRaw("Mouse Y");
        keyboardH = Input.GetAxis("Horizontal");


        sprint = Input.GetKey(KeyCode.LeftShift);
        castSpell = Input.GetKeyDown(KeyCode.Mouse0);
        /*if (Input.GetKeyDown(KeyCode.W)) {
            Debug.Log("W Press");
            HandleLocomotionForward(sprint);
        }*/

        forwardPressed = Input.GetKey(KeyCode.W);
        backwardPressed = Input.GetKey(KeyCode.S);


        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));


    }


    private void FixedUpdate() {
        HandleLocomotionForward(sprint, forwardPressed);
        HandleWalkBack(backwardPressed);
        HandleRotation(mouseH, mouseV);
        HandleStrafe(keyboardH);
        if (!sprint) {
            HandleAttack(castSpell);
        }


    }



    /*private void OnAnimatorIK(int layerIndex) {

        Vector3 head = GameObject.FindWithTag("Head").transform.position;
        lookDir = (ray.GetPoint(1000f) - head).normalized;
        //anim.SetLookAtPosition(lookDir);
    }*/


    private void HandleRotation(float horizontal, float vertical) {
        mouseInput = new Vector2(horizontal, vertical);
        mouseInput = Vector2.Scale(mouseInput, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothVec.x = Mathf.Lerp(smoothVec.x, mouseInput.x, 1f / smoothing);
        smoothVec.y = Mathf.Lerp(smoothVec.y, mouseInput.y, 1f / smoothing);
        mouseLook += smoothVec;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -30f, 10f);

        //transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
        anim.SetFloat("horizontalMouseV", mouseH, 1f, Time.deltaTime);
        rBody.MoveRotation(Quaternion.AngleAxis(mouseLook.x, Vector3.up));
        Camera.main.transform.localRotation = Quaternion.Slerp(Camera.main.transform.localRotation, Quaternion.AngleAxis(-mouseLook.y, Vector3.right), 1f / smoothing);
        //transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.AngleAxis(-mouseLook.y, Vector3.right), 1f / smoothing);

    }


    private void HandleLocomotionForward(bool sprinting, bool forwardP) {
        //Debug.Log("Loco");
        Vector2 t = new Vector2(0f, forwardP ? 1f : 0f);
        speedThreshold = Vector2.ClampMagnitude(t, 1f).magnitude;

        if (sprinting && forwardP) {
            speedThreshold = sprintSpeed;
            moveSpeed = sprintSpeed;
            Debug.Log("Sprint");
            anim.SetFloat("Speed", speedThreshold, speedDamping, Time.deltaTime);
            camfov.FOVset(90f);
        } else {
            if (speedThreshold >= 0.01f && speedThreshold < 1f) moveSpeed = walkSpeed;
            if (speedThreshold >= 1f && speedThreshold < 2f) moveSpeed = runSpeed;
            anim.SetFloat("Speed", speedThreshold, speedDamping, Time.deltaTime);
        }


        if (forwardP && !anim.GetBool("isStrafing")) {
            rBody.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed);
        }
        //anim.SetFloat("Speed", speedThreshold, speedDamping, Time.deltaTime);       
    }


    private void HandleWalkBack(bool backwardP) {
        if (backwardP && !anim.GetBool("isStrafing")) {
            anim.SetFloat("Speed", 0f);
            rBody.MovePosition(transform.position + (-transform.forward) * Time.deltaTime * backSpeed);
            anim.SetBool("isWalkingBack", true);
        } else {
            anim.SetBool("isWalkingBack", false);
        }
    }


    private void HandleStrafe(float h) {
        if (h != 0) {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Locomotion") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.WalkBack")) {
                anim.SetBool("isStrafing", true);
                if (h < 0) {
                    rBody.MovePosition(transform.position + (-transform.right) * Time.deltaTime * strafeSpeed);
                }
                if (h > 0) {
                    rBody.MovePosition(transform.position + transform.right * Time.deltaTime * strafeSpeed);
                }
                anim.SetFloat("horizontalKeyboardV", h, speedDamping, Time.deltaTime);
            }
        } else {
            anim.SetBool("isStrafing", false);
        }
    }


    private void HandleAttack(bool attacking) {
        if (attacking) {
            anim.SetTrigger("isAttacking");
        } else {
            anim.ResetTrigger("isAttacking");
        }
    }

    private void OnCollisionExit(Collision collision) {
        rBody.velocity = Vector3.zero;
    }
}

