using UnityEngine;

public class LaunchPad : MonoBehaviour {

    public float height = 1f;

    // Attacker Prefab that will be spawned
	public GameObject [] attackers;

    public GameObject leftRubber, rightRubber;

    // Is there a Bird in the Trigger Area?
    bool occupied = false;
	private int totalAttackers, currentCount = 0;

    private Vector3 slingCenter;
    private static LaunchPad instance;
    private Rubber left, right;

    void Awake()
    {
        instance = this;
    }

    public static LaunchPad locate()
    {
        return instance;
    }

    void Start() {

		if(attackers != null)
			totalAttackers = attackers.Length;

		if (totalAttackers == 0)
			return;
        
     //   Renderer r = GetComponent<Renderer>();
     //   float ht = r.bounds.extents.y;

        slingCenter = new Vector3(transform.position.x, transform.position.y + height, 0f);

        left = leftRubber.GetComponent<Rubber>();
        right = rightRubber.GetComponent<Rubber>();

		// set the waiting line
		for (int i=0; i<totalAttackers; i++) {
			float posX = transform.position.x + i;
			float posY = transform.position.y -1f;
			Vector2 pos = new Vector2(posX, posY);
			attackers[i] = (GameObject) Instantiate(attackers[i], pos, Quaternion.identity);
			attackers[i].transform.position = pos;
		}
	}

    void FixedUpdate() {
        // Attacker not in Trigger Area anymore? And nothing is moving?
        // Note: sceneMoving() isn't working well in higher versions of Unity
        // so we just let the other guy hop on the launcher, regardless
        if (!occupied) //  && !sceneMoving())  <- 
            Invoke("spawnNext", 1f);      // let current guy fly out
    }
	
    void spawnNext() {

        if (occupied == true)
            return;

        occupied = true;

        if (currentCount >= totalAttackers)		// count will be zero if array is not initialized
			return;
        // Spawn Attacker at current position with default rotation		
        attackers[currentCount].transform.position = slingCenter; // transform.position;
		attackers [currentCount].GetComponent<Attacker> ().setReady (true);
		
		currentCount ++;
    }


    public void attackerLaunched()  // place next attacker
    {
        occupied = false;           // get next guy in line to jump on a  sling

        // reset rubbers
        left.reset();
        right.reset();
    }

    bool sceneMoving() {
        // Find all Rigidbodies, see if any is still moving a lot
        Rigidbody2D[] bodies = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach (Rigidbody2D rb in bodies)
            if (rb.velocity.sqrMagnitude > 5)
                return true;
        return false;
    }

    // move rubbers together as the attacker is pulled and released
    public void dragRubber(Vector2 obj, float length)
    {
        left.stretch(obj, length);
        right.stretch(obj, length);
    }

}

