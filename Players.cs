using System.Collections;
using System.Collections.Generic;
//using System.Collections.Specialized;
using UnityEngine;

public class Players : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    public string ID;
    public bool delete;
    public Vector3 Pos;
    public ServerNetwork SN;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        delete = false;
        SN = GameObject.Find("ServerNetwork").GetComponent<ServerNetwork>();
        Pos = Vector3.zero;
        speed = 5.0f; 
    }

    // Update is called once per frame
    void Update()
    {
        if (delete)
            Destroy(gameObject);
        
        if (ID != SN.myAddress)
        {
            transform.position = Pos;
            return;
        }

        //move
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"),
                                             Input.GetAxis("Vertical"));
        movementVector *= speed;

        rb.velocity = movementVector;
        /*
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * Time.deltaTime * speed);


        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(-Vector3.left * Time.deltaTime * speed);
        */

    }
}

    
