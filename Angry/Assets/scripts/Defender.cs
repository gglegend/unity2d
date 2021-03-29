using UnityEngine;

public class Defender : MonoBehaviour {

    SpriteRenderer image;  // to change colors 

    void Start()
    {
        image = GetComponent<SpriteRenderer>();
    }

    void TakeDamage(int amount) {

        // Change sprite colors when get down to 50% and 25% of health, 
        // and when applicable, die by destroying the game object
    }

    /////////////////////////////////////////////////////////////
    //// Defenter is hit by something - find out what it was ////
    //// and calculate the corresponding damage amount  /////////
    /////////////////////////////////////////////////////////////
    void OnCollisionEnter2D (Collision2D other) {

		if (other.gameObject.tag == "defender")
			return;		// no harm

		Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();

		if( other.gameObject.tag == "attacker" )  //  direct hit 
                TakeDamage(16);

		if (other.gameObject.tag == "ground") { //  fell down onto the ground
			if (gameObject.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > 3) { // falling fast enough
                TakeDamage(6); 
			}
		} 
		else {
			if (other.gameObject.tag == "stone") {			
                    TakeDamage(12);                                       
            } else {
                TakeDamage(6);     
            }            
		}
	}
	
}