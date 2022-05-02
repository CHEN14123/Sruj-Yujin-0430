using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear_Count3 : MonoBehaviour
{
    public BallController Player;
    public void Start()
    {
        //Player = new BallController();
        //this.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        
        Debug.Log("Count value inside Update" + Player.count.ToString());
        if (Player.count==3)
        {
            Debug.Log("Happend");
            //this.gameObject.SetActive(true);
        }
    }
}
