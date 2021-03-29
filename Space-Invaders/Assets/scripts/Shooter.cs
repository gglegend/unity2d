using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject weapon;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot(Vector2.up);
    }
    void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(weapon, transform.position, Quaternion.identity);

        bullet.transform.parent = null;     // detach from platform 
        bullet.GetComponent<Rigidbody2D>().AddForce(direction);     // up or down
        Destroy(bullet, 3f);        // nothing lasts forever
        
    }

}
