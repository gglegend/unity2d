using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpy : MonoBehaviour {

    public float startJump;
    public float jumpFrequency;

    private Vector3 originalPos;
    private Vector3 up = new Vector3(0f, 0.1f, 0f);

    private bool idle = true;
    private Attacker atk;

    // Use this for initialization
    void Start () {
        if (startJump == 0f)
            startJump = 2;
        if (jumpFrequency == 0f)
            jumpFrequency = 2f;

        originalPos = transform.position;

        atk = GetComponent<Attacker>();
        if (atk != null) {
            idle = atk.isIdle();     // maybe sitting on the launchpad
        }

        InvokeRepeating("jump", startJump, jumpFrequency);
	}
	
    private void jump() {

        if (idle == false)
            return;

        transform.position += up;
        Invoke("comeBack", 0.2f);
    }

    private void comeBack() {
        transform.position = originalPos;
    }

    void FixedUpdate() {

        if (atk == null)
            return;

        idle = atk.isIdle();
    }

}
