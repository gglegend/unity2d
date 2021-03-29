using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodding : MonoBehaviour {

    public float startNod;
    public float nodFrequency;
    public float nodAngle;

    private Quaternion originalRot;
    // private Vector3 up = new Vector3(0f, 0.1f, 0f);
    private bool idle = true;

    private Attacker atk;

    // Use this for initialization
    void Start() {

        originalRot = transform.rotation;

        atk = GetComponent<Attacker>();
        if (atk != null) {
            idle = atk.isIdle();     // maybe sitting on the launchpad
        }

        if (idle == false)
            return;

        if (startNod == 0f)
            startNod = 2;
        if (nodFrequency == 0f)
            nodFrequency = 2f;
        if (nodAngle == 0f)
            nodAngle = 5f;

        InvokeRepeating("nod", startNod, nodFrequency);
    }

    private void nod() {

        if (idle == false)
            return;

        transform.Rotate(0f, 0f, nodAngle);
        Invoke("comeBack", 0.2f);
    }

    private void comeBack() {
        transform.rotation = originalRot;
    }
    
    void FixedUpdate() {

        if (atk == null)
            return;

        idle = atk.isIdle();
    }
}
