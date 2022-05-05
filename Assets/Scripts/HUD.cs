using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{    /// <summary>
     /// Score calculating and swoing component
     /// </summary>
    [SerializeField]
    Text scoreText;

    //timer
    float elapsedSeconds = 0;

    //stop the timer, when the game object is destroyed
    bool gameTimer = true;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer)
        {
            elapsedSeconds = (elapsedSeconds + Time.deltaTime);
            scoreText.text =((int)elapsedSeconds).ToString();
        }
    }
    public void StoGameTimer()
    {
        gameTimer = false;
    }
}
