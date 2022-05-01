using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scoreText;

    public int theScore;
    //public AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        //collectSound.Play();
       
        //theScore += 1;
        
       // scoreText.GetComponent<Text>().text = "SCORE: " + theScore;
        
        // Destroy(gameObject);
    }
}