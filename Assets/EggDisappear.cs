using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDisappear : MonoBehaviour
{
    public float time = 5.0f;

    // Start is called before the first frame update
    /* private void Start()
     {
         StartCoroutine(ShowAndHide(time));
     }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(ShowAndHide(time));
        }
    }

    private IEnumerator ShowAndHide(float delay)
    {
        this.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}