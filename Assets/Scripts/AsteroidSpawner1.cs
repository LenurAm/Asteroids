using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject prefabAsteroid;
    void Start()
    {
       //get the asteroid radius 
      GameObject asteroid=Instantiate<GameObject>(prefabAsteroid);
        CircleCollider2D circleCollider = asteroid.GetComponent<CircleCollider2D>();
        float radius = circleCollider.radius;
        Destroy(asteroid);

        //calculate Screen Width and Height
        float screenWidth=ScreenUtils.ScreenRight-ScreenUtils.ScreenLeft;
        float screenHeight=ScreenUtils.ScreenTop-ScreenUtils.ScreenBottom;

        //initialising the right asteroid
        asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroid1 script = asteroid.GetComponent<Asteroid1>();
        script.Initialize(Direction1.Right, new Vector2(ScreenUtils.ScreenRight-
            radius,ScreenUtils.ScreenBottom+screenHeight/2));

        //initialising the bottom asteroid
        asteroid = Instantiate<GameObject>(prefabAsteroid);
        script = asteroid.GetComponent<Asteroid1>();
        script.Initialize(Direction1.Up, new Vector2(ScreenUtils.ScreenLeft+
            screenWidth/2, ScreenUtils.ScreenBottom +radius));

        //initialising the top asteroid
        asteroid = Instantiate<GameObject>(prefabAsteroid);
        script = asteroid.GetComponent<Asteroid1>();
        script.Initialize(Direction1.Down, new Vector2(ScreenUtils.ScreenLeft +
            screenWidth / 2, ScreenUtils.ScreenTop - radius));

        //initialising the left asteroid
        asteroid = Instantiate<GameObject>(prefabAsteroid);
        script = asteroid.GetComponent<Asteroid1>();
        script.Initialize(Direction1.Left, new Vector2(ScreenUtils.ScreenLeft +
            radius, ScreenUtils.ScreenBottom + screenHeight/2));

    }

    
}
