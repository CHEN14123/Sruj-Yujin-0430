using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  //Adds automatic rigidbody when this script is added to the GameObject
public class BallController : MonoBehaviour
{
    public float Speed = 30;
    public int count = 0;
    private int p = 0;
    private Camera _camera;
    private Rigidbody _rigidbody;
    private List<GameObject> selectorArr;
    public List<Material> MatArr;
    public Material Material1;
    public PositionZ Score1;

    public GameObject prefabParent;
    public List<GameObject> prefabs;



    // Start is called before the first frame update
    private void Start()
    {
        prefabs = new List<GameObject>();
        foreach (Transform child in prefabParent.transform)
        {
            prefabs.Add(child.gameObject);
        }

        foreach(GameObject prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }

        selectorArr = new List<GameObject>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _camera = Camera.main; //singleton pattern
        Score1 = new PositionZ();
       
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(x, 0, -z);
        //Debug.Log(input);
        Vector3 move = (input.z * _camera.transform.forward) + (input.x * _camera.transform.right);
        _rigidbody.AddForce(move * Speed*2 * Time.fixedDeltaTime * Size);
        //Score1.getUpdate(count);
    }

    private float Size = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sticky") && collision.transform.localScale.magnitude <= Size)
        {
            
            count = count + 1;
           
            Debug.Log("Count value now" +count);
            /*for(int i = 0;i<prefabs.Count;i++)
            {
                if(count > ((i+1) * 3)) { continue; }//skip
                prefabs[i].gameObject.SetActive(true);
                this.GetComponent<MeshRenderer>().material = MatArr[Random.Range(0,MatArr.Count)]; //random number
            }*/
            Debug.Log(p);
            if (count % 3 == 0 && count!= 0)
            {
                
                prefabs[p].gameObject.SetActive(true);
                p = p + 1;
                
                this.GetComponent<MeshRenderer>().material = MatArr[Random.Range(0, MatArr.Count)]; //random number
            }
            

            


            Debug.Log("count=" + count);
            //Score1.count_tmp = Score1.count_tmp + 1;
            collision.transform.parent = this.transform;
            Size += collision.transform.localScale.magnitude;
            

            if (collision.gameObject.GetComponent<Rigidbody>())
            {
                Destroy(collision.gameObject.GetComponent<Rigidbody>());
            }

            //selectorArr = new GameObject[3];
            selectorArr.Add(collision.gameObject);

            Debug.Log(selectorArr.Count);
            if (selectorArr.Count % 3==0)
            {
                //Debug.Log("3");
                for (int i = 0; i < selectorArr.Count; i++)
                {
                    Destroy(selectorArr[i]);
                }

                selectorArr = new List<GameObject>(); //reset list
                //this.transform.localScale = this.transform.localScale * 1.5f;//
                
                //GameObject particle = Instantiate(Prefab, transform.position, transform.rotation) as GameObject;
                //particle.transform.parent = this.transform;
                //Prefab.gameObject.parent=this.transform;

                //change prefab with collision.
                //Score for the UI
            }
        }
    }
}