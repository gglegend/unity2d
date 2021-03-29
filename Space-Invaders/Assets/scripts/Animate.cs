using UnityEngine;
using System.Collections;

// a simple two-sprite animation
public class Animate : MonoBehaviour {
	
	public Sprite image1, image2;
	public float flickSpeed = 1f;  // how quickly do we flip images

	private SpriteRenderer sr;
		
	void Start () {

        sr = GetComponent<SpriteRenderer>();
        InvokeRepeating("FlipImage", flickSpeed, flickSpeed);
	}
	
	void FlipImage() {

		if (sr.sprite == image1)
			sr.sprite = image2;
		else
		    sr.sprite = image1;

    }
}
