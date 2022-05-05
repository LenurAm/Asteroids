using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1 : MonoBehaviour
{
    [SerializeField]
    Sprite greenasteroid;
    [SerializeField]
    Sprite magentaasteroid;
    [SerializeField]
    Sprite whiteasteroid;
    // Start is called before the first frame update
    /// <summary>
    /// Asteroid mooving
    /// </summary>
    
    const float MaxImpulseForce = 2f;
    const float MinImpulseForce = 0.1f;
    void Start()
    {
        

        //float angle=Random.Range(0,Mathf.PI*2);
        //Vector2 direction=new Vector2(Mathf.Cos(angle),Mathf.Sin(angle));
        //float magnitutde=Random.Range(MinImpulseForce,MaxImpulseForce);
        //GetComponent<Rigidbody2D>().AddForce(direction * magnitutde, ForceMode2D.Impulse);


        //initiate random asteroid
        SpriteRenderer spriteRenderer=GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        switch (spriteNumber)
        {
            case 0:
                
                spriteRenderer.sprite = greenasteroid;
                
                break;
            case 1:
                
                spriteRenderer.sprite = magentaasteroid;
                
                break;
            case 2:
                
                spriteRenderer.sprite = whiteasteroid;
               
                break;
            default:
                break;

        }
        
    }
    public void Initialize (Direction1 direction1, Vector3 position)
    {
        transform.position = position;
        float baseAngle=0;
        float randomAngle=Random.value*30f*Mathf.Deg2Rad;

        if (direction1==Direction1.Up)
        {
            baseAngle=randomAngle+75*Mathf.Deg2Rad;
        }
        if (direction1==Direction1.Right)
        { baseAngle=randomAngle+165*Mathf.Deg2Rad;}
        if (direction1==Direction1.Down)
        { baseAngle=randomAngle+255*Mathf.Deg2Rad;}
        if (direction1==Direction1.Left)
        {
            baseAngle=randomAngle+345*Mathf.Deg2Rad ;
        }

        Vector2 moveDirection = new Vector2(Mathf.Cos(baseAngle), Mathf.Sin(baseAngle));
        float magnitutde = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitutde, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.CompareTag("Ship"))
        //{ Destroy(gameObject); }
            
        if (col.gameObject.CompareTag("Bullet"))
        {
            //Dectroy bullet
            Destroy(col.gameObject);
            //play the sound when asteroid is hitted
            AudioManager.Play(AudioClipName.AsteroidHit);
            //cut the asteroid half

            //get the scale of asteroid
            Vector3 halfAsteroid = gameObject.transform.localScale;
            //cut the asteroids' collider on half due to the collision
            CircleCollider2D radius=gameObject.GetComponent<CircleCollider2D>();
            float newRadius=radius.radius;
            newRadius = newRadius / 2;
            radius.radius = newRadius;
                
                       
            halfAsteroid.x = halfAsteroid.x / 2;
            halfAsteroid.y = halfAsteroid.y / 2;
            //change asteroid size
            gameObject.transform.localScale = halfAsteroid;

            

            //check the asteroid size
            if ((halfAsteroid.x < 0.5) && (halfAsteroid.y < 0.5))
            { //if asteroid less than half, destroy it
                Destroy(gameObject);
            }
            else
            //instatiate new asteroids
            {
                GameObject newAsteroid = Instantiate<GameObject>(gameObject);
                GameObject newAsteroid1=Instantiate<GameObject>(gameObject);
                //move the new small asteroids
                Asteroid1 script=newAsteroid.GetComponent<Asteroid1>();
                script.StartMoving();
                Asteroid1 script1=newAsteroid1.GetComponent<Asteroid1>();
                script1.StartMoving();
                //destro the big one asteroid
                Destroy(gameObject);
                
            }




        }

    }
    /// <summary>
    /// two small asteroids start moving in random direction
    /// </summary>
    public void StartMoving()
    {
        
        float randomAngle = Random.Range(0,2 *Mathf.PI);
        Vector2 moveDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        float magnitutde = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitutde, ForceMode2D.Impulse);
    }
        
    
}



