using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
       
    public Text winText;

    private Rigidbody rb;

    private Ray forward,back,left,right;

   void Start()
    {
        rb = GetComponent<Rigidbody>();

        

        winText.text = "";
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(0, 0.5f, 0);

            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
            
            winText.text = "";

        }



    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);
        

        rb.AddForce(movement * speed);


        RaycastHit hit;

        Ray forward = new Ray(transform.position, Vector3.forward);
        Ray back = new Ray(transform.position, Vector3.back);
        Ray left = new Ray(transform.position, Vector3.left);
        Ray right = new Ray(transform.position, Vector3.right);

        if (Physics.Raycast(forward, out hit, 2.0f) || Physics.Raycast(back, out hit, 0.5f) || Physics.Raycast(left, out hit, 0.5f) || Physics.Raycast(right, out hit, 0.5f))
        {
            if (hit.collider.tag == "buildings")
            {
                rb.AddForce(-movement * speed);

            }

        }


     }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("buildings"))
        {
           
            rb.velocity = -rb.velocity * 0.25f;
            rb.angularVelocity = -rb.angularVelocity * 0.25f;
            
                      
            winText.text = "hit building";

        }
    }

    





}