using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlienMove : MonoBehaviour {

    public float moveInterval;
	protected enum Direction { Left, Right, Down };
   
	private bool alive = true;
    private Direction dir = Direction.Down;
    private int numSteps = 0;
    private Direction lastHoriz = Direction.Left;

    void Start()
    {
        if (moveInterval == 0f)
            moveInterval = 1f;

        InvokeRepeating("MoveIt", 1f, moveInterval);
    }

	protected void move(Direction dir) {

        Vector2 v2 = new Vector2(transform.position.x, transform.position.y);

        if (dir == Direction.Right)
            transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
        else if (dir == Direction.Left)
            transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y-0.5f);
    }

    // Update is called once per frame
    void MoveIt () {
		
		if (alive == false)
			return;

        move(dir);

        // 5 steps left, 1 down, 5 steps right, 1 down, etc..
        if (dir == Direction.Left || dir == Direction.Right)
        {
            numSteps++;
            if (numSteps > 5)
            {
                numSteps = 0;
                dir = Direction.Down;
            }
            return;
        }

        // not left or right, so our last move was down
        if(lastHoriz == Direction.Left)
        {
            dir = Direction.Right;
            lastHoriz = Direction.Right;
        }
        else
        {
            dir = Direction.Left;
            lastHoriz = Direction.Left;
        }
    }

}
