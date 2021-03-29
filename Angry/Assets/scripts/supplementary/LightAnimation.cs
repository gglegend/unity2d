using UnityEngine;

public class LightAnimation : MonoBehaviour {

    public Sprite regular, blinking, nodding; //headTiltRight, headTiltLeft;
    protected SpriteRenderer sr;
    public float normalTime = 20f, sleepyTime = 5f, tiltHeadTime = 10f;

    private const int NORMAL1 = 0, SLEEPY = 1, RIGHT = 2, NORMAL2 = 3, NODDING = 4;     // LEFT = 4, NORMAL3 = 5;
    private int currentState = NORMAL1;

    private float timeShown, timeNeeded = 0;        // ms

    void Start () {
        sr = GetComponent<SpriteRenderer>();
        timeNeeded = normalTime; // start with normal animation
    }
	
	void Update () {
        // self-aniating, or externally controlled and isShowing set by ctrller

        timeShown++;  //  will slightly differ, depending on the frame rate.. maybe will feel more 'alive'?
       if (timeShown % timeNeeded == 0)        
            flipImage();

    }

    private void flipImage() {

        // state transition: regular -> blinking -> regular -> nodding  (back to start)
        timeShown = 0;
        switch(currentState) {
            case NORMAL1:       // normal -> sleepy
                sr.sprite = blinking;
                timeNeeded = sleepyTime;
                currentState = SLEEPY;
                break;
            case SLEEPY:
                sr.sprite = regular;
                timeNeeded = normalTime;
                currentState = NORMAL2;
                break;
            case NORMAL2:
                sr.sprite = nodding;
                timeNeeded = tiltHeadTime;
                currentState = NODDING;
                // test of damage modeling:
              //  sr.color = Color.blue;
                break;
             case NODDING:
                sr.sprite = regular;
                timeNeeded = normalTime;
                currentState = NORMAL1;
                break;             
        }
        
    }
}
