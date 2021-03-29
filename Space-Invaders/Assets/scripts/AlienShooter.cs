using UnityEngine;

public class AlienShooter : MonoBehaviour {

    public GameObject weapon;


    void Start()
    {
        float period = Random.Range(0.5f, 3.0f);

        InvokeRepeating("Shoot", period, period);
    }
   
    
    void Shoot()
    {
        GameObject bullet = Instantiate(weapon, transform.position, Quaternion.identity);

        bullet.transform.parent = null;     // detach from platform 
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down);     // up or down
        Destroy(bullet, 3f);        // nothing lasts forever



    }

}
