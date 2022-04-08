using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// The bullet is moving script
    /// </summary>
    const float DeathTimer = 2;
    Timer deathTimer;
    void Start()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = DeathTimer;
        deathTimer.Run();


    }
    public void ApplyForce (Vector2 direction)
    {
        const float magnitudeBullet = 10;
        
        GetComponent<Rigidbody2D>().AddForce(
            magnitudeBullet*direction, 
            ForceMode2D.Impulse);
    }
    void Update()
    {
        if (deathTimer.Finished)
            Destroy(gameObject);
    }



}
