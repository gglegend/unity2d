using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderMove : MonoBehaviour
{
    public float speed = 1f;
    static int life = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector2.right * Time.deltaTime * speed);

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
 

        print("Collided with " + col);
        if (col.gameObject.tag == "alienWeapon")
            life = life -1;

        if (life == 0)
            Destroy(gameObject);

        print(life);
    }
}
