using UnityEngine;

// left and right sling's rubbers - stretch and reset
public class Rubber : MonoBehaviour {

    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    public void stretch(Vector2 itemPos, float itemSize) {

        // Rotation
        Vector2 dir = startPos - itemPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Length
        float dist = Vector3.Distance(itemPos, transform.position);
        dist += itemSize; 
        transform.localScale = new Vector2(dist, 1);
    }

    public void reset() {

        transform.localScale = new Vector2(0, 1);
        transform.rotation = Quaternion.identity;
    }
}
