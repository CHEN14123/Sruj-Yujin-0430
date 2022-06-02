using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public float velocity;
    void Update()
    {
       if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jumping");
            GetComponent<Rigidbody2D>().velocity = Vector2.up * velocity;
        } 
    }
}
