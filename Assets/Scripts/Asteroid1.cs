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
    
    const float MaxImpulseForce = 5f;
    const float MinImpulseForce = 2f;
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
        if (col.gameObject.CompareTag("Ship"))
            Destroy(gameObject);
    }


}
