using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper1 : MonoBehaviour
{
    // Start is called before the first frame update
    float radius;
    void Start()
    {
        radius = GetComponent<CircleCollider2D>().radius;

    }
    void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        {
            if (position.x - radius < ScreenUtils.ScreenLeft ||
                  position.x + radius > ScreenUtils.ScreenRight)
            {
                position.x *= -1;
            }
            if (position.y + radius > ScreenUtils.ScreenTop ||
                position.y - radius < ScreenUtils.ScreenBottom)
            {
                position.y *= -1;
            }
        }

        // move the starship
        transform.position = position;
    }
}

  
