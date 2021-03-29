using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(1f, 10f)]
    public float mass;      // once dynamic body takes effect   

    // The energy added upon release
    private float energy = 1000;

    private float dragRadius = 1.8f;
    private bool isReady;
    private bool isLaunched = false;

    // The default Position
    Vector2 startPos;

	private float ttl = 5f;     // time to live after launch from a slingshot

    private Rigidbody2D body;
    private LaunchPad sling;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        body = GetComponent<Rigidbody2D>();
        sling = LaunchPad.locate();
    }

    public bool isIdle() {      // when Animal is idle it can be animated
        return isReady == false;
    }

	public void setReady(bool b) {
		isReady = b;
		startPos = transform.position; 
	}
    
    void OnMouseUp() {
        
		if (isReady == false)
			return;

		if (isLaunched == true)
			return;

        Vector2 dir = startPos - (Vector2)transform.position;

        // simple mouse clicks or tiny movement should not lead to launch:
        if (Mathf.Abs(dir.magnitude) < 0.4f)
        {    
            transform.position = startPos;
            return;
        }
        // Let the Unity physics engine kick in
        body.isKinematic = false;
        body.mass = mass;

        // Add the Force
        body.AddForce(dir * energy);

		isLaunched = true;

        sling.attackerLaunched();  // place next one in the sling
      
        Destroy(gameObject, ttl);      // destroy after a given period
    }


    void OnMouseDrag() {        

		if (isReady == false)
			return;

		if (isLaunched == true)
			return;

        // Convert mouse position to world position
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Keep it in a certain radius
        //float radius = 1.8f;
        Vector2 dir = p - startPos;
		if (dir.sqrMagnitude > dragRadius)
			dir = dir.normalized * dragRadius;

        // Set the Position
        transform.position = startPos + dir;

        sling.dragRubber(transform.position, transform.localScale.x);
    }
	
}