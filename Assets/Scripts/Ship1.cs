using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship1 : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBullet;
    [SerializeField]
    HUD hud;

    Rigidbody2D rb2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 5;
    //float radius;
    const float RotateDegreesPerSecond = 60;
    
    // Start is called before the first frame update
    void Start()
    {
        //radius = GetComponent<CircleCollider2D>().radius;
        rb2D = GetComponent<Rigidbody2D>();       
    }
   
   
    // Update is called once per frame
    void Update()
    {
        //calculate rotation amount and apply rotation
        float rotationInput = Input.GetAxis("Rotate");
        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
        if (rotationInput != 0)
        {
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            //if (rotationAmount > 0)
            //   { rotationAmount*=1;}
            //if (rotationAmount == 0)
            //   { rotationAmount *= 0; }
            transform.Rotate(Vector3.forward, rotationAmount);
            float zRotation=transform.eulerAngles.z*Mathf.Deg2Rad;
            thrustDirection.x=Mathf.Cos(zRotation);
            thrustDirection.y=Mathf.Sin(zRotation);

        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject bullet = Instantiate<GameObject>(prefabBullet,transform.position,Quaternion.identity);
            Bullet script=bullet.GetComponent<Bullet>();
            script.ApplyForce(thrustDirection);
            AudioManager.Play(AudioClipName.PlayerShot);
               
        }
    }
    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") != 0)
        {
               rb2D.AddForce(
                thrustDirection * ThrustForce,
                ForceMode2D.Force);
        }
    }
    //destroy thew ship when collide with asteroids
   void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Asteroid"))
        {
            hud=hud.GetComponent<HUD>();
            hud.StoGameTimer();
            //play the sound of ship destroing
            AudioManager.Play(AudioClipName.PlayerDeath);
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
    //void OnBecameInvisible()
    //{
    //    Vector2 position = transform.position;

    //    {
    //        if (position.x + radius < ScreenUtils.ScreenLeft ||
    //              position.x - radius > ScreenUtils.ScreenRight)
    //        {
    //            position.x *= -1;
    //        }
    //        if (position.y - radius > ScreenUtils.ScreenTop ||
    //            position.y + radius < ScreenUtils.ScreenBottom)
    //        {
    //            position.y *= -1;
    //        }
    //    }

    //    // move the starship
    //    transform.position = position;
    //}
}
