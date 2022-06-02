using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//B,W,G,B,B

[RequireComponent(typeof(Rigidbody))]  //Adds automatic rigidbody when this script is added to the GameObject
public class Ball_Controller_2 : MonoBehaviour
{
    public float Speed = 30;
    public static int count_black = 0;
    public static int count_green = 0;
    public static int count_white = 0;
    public static int count = 0;
    private int p = 0;
    private Camera _camera;
    private Rigidbody _rigidbody;
    private List<GameObject> selectorArr_black;
    private List<GameObject> selectorArr_green;
    private List<GameObject> selectorArr_white;


    //public GameObject prefabParentBlack;
    //public GameObject prefabParentGreen;
    //public GameObject prefabParentWhite;

    public Vector3 input, move;

    public GameObject black_1;
    public GameObject green_1;
    public GameObject white_1;



    // Start is called before the first frame update
    private void Start()
    {
        selectorArr_black = new List<GameObject>();
        selectorArr_white = new List<GameObject>();
        selectorArr_green = new List<GameObject>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _camera = Camera.main; //singleton pattern
    }



    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Jump");
        input = new Vector3(x, y, -z);
        Debug.Log(input);
        move = (input.z * _camera.transform.forward) + (input.x * _camera.transform.right) + (input.y * _camera.transform.right);
        _rigidbody.AddForce(move * Speed * 2 * Time.fixedDeltaTime * Size);
        /*if ((Input.GetAxis("Jump") != 0))
        {
            _rigidbody.AddForce(new Vector3(0, -y, 0), ForceMode);
        }*/
        
    }

    private float Size = 1;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit Collider");
        if (collision.gameObject.CompareTag("Sticky") && collision.transform.localScale.magnitude <= Size)
        {
            //Debug.Log("Hit Sticky");


            if (collision.gameObject.GetComponent<MeshRenderer>().sharedMaterial == green_1.gameObject.GetComponent<MeshRenderer>().sharedMaterial)
            {
                selectorArr_green.Add(collision.gameObject);
                count_green = count_green + 1;
                //Debug.Log("Hit green");
            }
            if (collision.gameObject.GetComponent<MeshRenderer>().sharedMaterial == black_1.gameObject.GetComponent<MeshRenderer>().sharedMaterial)
            {
                selectorArr_black.Add(collision.gameObject);
                count_black = count_black + 1;
                Debug.Log("Hit black");
            }
            if (collision.gameObject.GetComponent<MeshRenderer>().sharedMaterial == white_1.gameObject.GetComponent<MeshRenderer>().sharedMaterial)
            {
                selectorArr_white.Add(collision.gameObject);
                count_white = count_white + 1;
                Debug.Log("Hit white");
            }

            count = count + 1;

            
            //Debug.Log("move=" + move);

           // Debug.Log("count_black=" + count_black);
           // Debug.Log("count_green=" + count_green);
           // Debug.Log("count_white=" + count_white);
            //Score1.count_tmp = Score1.count_tmp + 1;
            collision.transform.parent = this.transform;
            Size += collision.transform.localScale.magnitude;


            if (collision.gameObject.GetComponent<Rigidbody>())
            {
                Destroy(collision.gameObject.GetComponent<Rigidbody>());
            }

            Debug.Log("Black count"+selectorArr_black.Count);
            Debug.Log("White count"+selectorArr_white.Count);
            Debug.Log("Green count"+selectorArr_green.Count);
            if (selectorArr_black.Count % 3 == 0 & selectorArr_black.Count != 0)
            {
                //Debug.Log("3");
                _rigidbody.position = _rigidbody.position + new Vector3(3, 3, 3);
                Instantiate(black_1, _rigidbody.position, Quaternion.identity);
                Debug.Log("Destroy Black");
                for (int i = 0; i < selectorArr_black.Count; i++)
                {
                    Destroy(selectorArr_black[i]);
                }

                selectorArr_black = new List<GameObject>(); //reset list
                                                            //this.transform.localScale = this.transform.localScale * 1.5f;//
            }

            if (selectorArr_green.Count % 3 == 0 & selectorArr_green.Count != 0)
            {
                //Debug.Log("3");
                _rigidbody.position = _rigidbody.position + new Vector3(3, 3, 3);
                Instantiate(green_1, _rigidbody.position, Quaternion.identity);
                Debug.Log("Destroy Green");
                for (int i = 0; i < selectorArr_green.Count; i++)
                {
                    Destroy(selectorArr_green[i]);
                }

                selectorArr_green = new List<GameObject>(); //reset list
            }
            if (selectorArr_white.Count % 3 == 0 & selectorArr_white.Count != 0)
            {
                _rigidbody.position = _rigidbody.position + new Vector3(3, 3, 3);
                Instantiate(white_1, _rigidbody.position, Quaternion.identity);
                Debug.Log("Destroy White");
                for (int i = 0; i < selectorArr_white.Count; i++)
                {
                    Destroy(selectorArr_white[i]);
                }

                selectorArr_white = new List<GameObject>(); //reset list
            }

        }
    }
}