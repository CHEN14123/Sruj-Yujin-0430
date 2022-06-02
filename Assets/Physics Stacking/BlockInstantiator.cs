using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInstantiator : MonoBehaviour
{
    public List<GameObject> prefab;

    private float next_spawn_time;

    private float EntranceRate = 8.0f;
    private int count=0;
    private List<GameObject> selectorArr;
    private int n = 0;

    
    //public Transform generationPoint;

    //public float distanceBetween;
    //public GameObject[] theplatforms;

    //private float platformWidth;
    //private int platformSelector;

    // Start is called before the first frame update
    private void Start()
    {
        next_spawn_time = Time.time + EntranceRate;
        //prefab = new List<GameObject>();
    }

    // Update is called once per frame
    private void Update()
    {
        //EntranceRate = Random.Range(0.0f, 8.0f);
        //Debug.Log("Entrance Rate=" + EntranceRate);
        Vector3 position = new Vector3(Random.Range(-32, 32), 0.4f, Random.Range(-32, 32));

        n = Random.Range(0, prefab.Count);
        if (Time.time > next_spawn_time)
        {
            //do stuff here (like instantiate)
            //foreach(GameObject prefab in prefab) 
            //{ 
            //Instantiate(prefab[n], this.transform.position, Quaternion.identity);
            Instantiate(prefab[n], position, Quaternion.identity);
            //}

            //increment next_spawn_time
            next_spawn_time += EntranceRate;
        }

        // Instantiate(prefab, this.transform.position, Quaternion.identity);

        /* if (Input.GetMouseButtonDown(0))
         {
             Instantiate(prefab, this.transform.position, Quaternion.identity);
         }*/

        /*if (transform.position.y < generationPoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platformWidth + distanceBetween);
            platformSelector = Random.Range(0, theplatforms.Length);
            Instantiate(theplatforms[platformSelector], transform.position, transform.rotation);
        }*/
    }

   /* private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Sticky"))
        {
            //selectorArr = new GameObject[3];
            selectorArr.Add(collision.gameObject);
            //selectorArr[count] = collision.gameObject.GetInstanceID();
            //count = count + 1;
            //Debug.Log("Hit" + count);

            if (selectorArr.Count == 3)
            {
                for (int i =0; i< selectorArr.Count; i++)
                {
                    Destroy(selectorArr[i]);
                }
                selectorArr = new List<GameObject>(); //reset list
                //Destroy(prefab);
            }


        }
    }*/
}