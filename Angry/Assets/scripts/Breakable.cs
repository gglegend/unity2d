using UnityEngine;
using System.Collections.Generic;

public class Breakable : MonoBehaviour {

    [Range(1f, 1000f)]
    public float strength = 500f;
    public bool breakByMouseClick = false;  // for testing
    public AudioClip breakSound;

    private AudioSource audioSrc;
    List<GameObject> pieces = new List<GameObject>();

    void Start()
    {        
        audioSrc = (AudioSource)gameObject.AddComponent<AudioSource>(); // add on the fly                   
        audioSrc.volume = 0.5f;

        // collect all sub-pieces
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
            if (child.gameObject != gameObject)
            {
                GameObject piece = child.gameObject;
                piece.SetActive(false);  // so they don't jump around before their time
                pieces.Add(piece);
            }
    }
    
    private void OnCollisionEnter2D(Collision2D otherObj)
    {
        Rigidbody2D body = otherObj.gameObject.GetComponent<Rigidbody2D>();
        if (body == null)
            return;

        // impact energy = m * v^2  = mass * velocity squared
        float relativeSpeed = otherObj.relativeVelocity.sqrMagnitude;

        float impulse = relativeSpeed * body.mass;

        if (Mathf.Abs(impulse) >= strength)
            BreakUp();       
    }

    public void BreakUp()
    {
        if (audioSrc.isPlaying)
            return;     // we're already breaking up

        audioSrc.PlayOneShot(breakSound);
        GetComponent<SpriteRenderer>().sprite = null;  // hide main sprite
        GetComponent<BoxCollider2D>().enabled = false;  // so pieces could fly out

        foreach (GameObject piece in pieces)
        {
            piece.SetActive(true);
            Vector3 dir = getFlyoutDir();
            piece.GetComponent<Rigidbody2D>().AddForce(dir);
            Destroy(piece, 2f);
        }

        Destroy(gameObject, 2f);
    }

    Vector3 getFlyoutDir()
    {
        float x = Random.Range(-6f, 6.1f);
        float y = Random.Range(-2f, 6.1f);  
        Vector3 dir = new Vector3(x, y);
        return dir;
    }

    void OnMouseDown()
    {
        if (breakByMouseClick == true)
            BreakUp();
    }
}
