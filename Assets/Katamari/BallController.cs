using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  //Adds automatic rigidbody when this script is added to the GameObject
public class BallController : MonoBehaviour
{
    public float Speed = 30;
    public int count_black = 0;
    public int count_green = 0;
    public int count_white = 0;
    public int count = 0;
    private int p = 0;
    private int p_black = 0;
    private int p_green = 0;
    private int p_white = 0;
    private Camera _camera;
    private Rigidbody _rigidbody;
    //private List<GameObject> selectorArr;
    private List<GameObject> selectorArr_black;
    private List<GameObject> selectorArr_green;
    private List<GameObject> selectorArr_white;
    public List<Material> MatArr;
    public Material Material1;
    public PositionZ Score1;

    public GameObject prefabParentBlack;
    public GameObject prefabParentGreen;
    public GameObject prefabParentWhite;
    private List<GameObject> prefabs_black;
    private List<GameObject> prefabs_green;
    private List<GameObject> prefabs_white;
    //public List<GameObject> prefabs;


    public Material material_name;



    // Start is called before the first frame update
    private void Start()
    {
        prefabs_black = new List<GameObject>();
        foreach (Transform child in prefabParentBlack.transform)
        {
            prefabs_black.Add(child.gameObject);
        }

        foreach (GameObject prefab in prefabs_black)
        {
            prefab.gameObject.SetActive(false);
        }



        prefabs_green = new List<GameObject>();
        foreach (Transform child in prefabParentGreen.transform)
        {
            prefabs_green.Add(child.gameObject);
        }

        foreach (GameObject prefab in prefabs_green)
        {
            prefab.gameObject.SetActive(false);
        }


        prefabs_white = new List<GameObject>();
        foreach (Transform child in prefabParentWhite.transform)
        {
            prefabs_white.Add(child.gameObject);
        }

        foreach (GameObject prefab in prefabs_white)
        {
            prefab.gameObject.SetActive(false);
        }



        selectorArr_black = new List<GameObject>();
        selectorArr_white = new List<GameObject>();
        selectorArr_green = new List<GameObject>();
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
        Debug.Log("Hit Collider");
        if (collision.gameObject.CompareTag("Sticky") && collision.transform.localScale.magnitude <= Size)
        {
            Debug.Log("Hit Sticky");
            //material_name = gameObject.GetComponent<MeshRenderer>().material;

         
            if (collision.gameObject.GetComponent<MeshRenderer>().sharedMaterial == prefabs_green[1].gameObject.GetComponent<MeshRenderer>().sharedMaterial)
            {
                count_green = count_green + 1;
                Debug.Log("Hit green");
            }
            else if (collision.gameObject.GetComponent<MeshRenderer>().sharedMaterial == prefabs_black[1].gameObject.GetComponent<MeshRenderer>().sharedMaterial)
            {
                count_black = count_black + 1;
                Debug.Log("Hit black");
            }
            else if (collision.gameObject.GetComponent<MeshRenderer>().sharedMaterial == prefabs_white[1].gameObject.GetComponent<MeshRenderer>().sharedMaterial)
            {
                count_white = count_white + 1;
                Debug.Log("Hit white");
            }

            count = count + 1;
           
            //Debug.Log("Count value now" +count);
            /*for(int i = 0;i<prefabs.Count;i++)
            {
                if(count > ((i+1) * 3)) { continue; }//skip
                prefabs[i].gameObject.SetActive(true);
                this.GetComponent<MeshRenderer>().material = MatArr[Random.Range(0,MatArr.Count)]; //random number
            }*/
            Debug.Log(p_black);
            Debug.Log(p_white);
            Debug.Log(p_green);

            if (count_black % 3 == 0 && count_black!= 0)
            {
                
                prefabs_black[p_black].gameObject.SetActive(true);
                p_black = p_black + 1;
                
                //this.GetComponent<MeshRenderer>().material = MatArr[Random.Range(0, MatArr.Count)]; //random number
            }
            else if (count_green % 3 == 0 && count_green != 0)
            {

                prefabs_green[p_green].gameObject.SetActive(true);
                p_green = p_green + 1;
                //this.GetComponent<MeshRenderer>().material = MatArr[Random.Range(0, MatArr.Count)]; //random number
            }
            else if (count_white % 3 == 0 && count_white != 0)
            {

                prefabs_white[p_white].gameObject.SetActive(true);
                p_white = p_white + 1;
                //this.GetComponent<MeshRenderer>().material = MatArr[Random.Range(0, MatArr.Count)]; //random number
            }




            Debug.Log("count_black=" + count_black);
            Debug.Log("count_green=" + count_green);
            Debug.Log("count_white=" + count_white);
            //Score1.count_tmp = Score1.count_tmp + 1;
            collision.transform.parent = this.transform;
            Size += collision.transform.localScale.magnitude;
            

            if (collision.gameObject.GetComponent<Rigidbody>())
            {
                Destroy(collision.gameObject.GetComponent<Rigidbody>());
            }

            //selectorArr = new GameObject[3];
            selectorArr_black.Add(collision.gameObject);
            selectorArr_white.Add(collision.gameObject);
            selectorArr_green.Add(collision.gameObject);


            Debug.Log(selectorArr_black.Count);
            Debug.Log(selectorArr_white.Count);
            Debug.Log(selectorArr_green.Count);
            if (selectorArr_black.Count % 3==0)
            {
                //Debug.Log("3");
                for (int i = 0; i < selectorArr_black.Count; i++)
                {
                    Destroy(selectorArr_black[i]);
                }

                selectorArr_black = new List<GameObject>(); //reset list
                //this.transform.localScale = this.transform.localScale * 1.5f;//
                
                //GameObject particle = Instantiate(Prefab, transform.position, transform.rotation) as GameObject;
                //particle.transform.parent = this.transform;
                //Prefab.gameObject.parent=this.transform;

                //change prefab with collision.
                //Score for the UI
            }

            else if (selectorArr_green.Count % 3 == 0)
            {
                //Debug.Log("3");
                for (int i = 0; i < selectorArr_green.Count; i++)
                {
                    Destroy(selectorArr_green[i]);
                }

                selectorArr_green = new List<GameObject>(); //reset list
            } 
            else if (selectorArr_white.Count %3 == 0)
            {
                for (int i = 0; i < selectorArr_white.Count; i++)
                {
                    Destroy(selectorArr_white[i]);
                }

                selectorArr_white = new List<GameObject>(); //reset list
            }    

        }
    }
}
