using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Navigator : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;
    //Speedometer Variables
    private Text speed_display;
    //Navigation Variables
    private GameObject left_marker;
    private GameObject right_marker;
    private GameObject straight_marker;
    private float x_val = 0.0f;
    private float z_val = 0.0f;
    // 1 = LEFT, 2 = RIGHT, 0 = STRAIGHT
    private int prev = 5;
    private Vector3 left = new Vector3(45.0f, 45.0f, 0.0f);
    private Vector3 right = new Vector3(-45.0f, 45.0f, 0.0f);
    private Vector3 straight = new Vector3(0.0f, 45.0f, 0.0f);

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        left_marker = GameObject.Find("direction_left");
        right_marker = GameObject.Find("direction_right");
        straight_marker = GameObject.Find("direction_straight");
        speed_display = GameObject.Find("Speedometer").GetComponent<Text>();
        straight_marker.SetActive(false);
        left_marker.SetActive(false);
        right_marker.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(target.position);
        speed_display.text = "Speed: "+Mathf.Round(Mathf.Sqrt(Mathf.Pow(agent.velocity.x,2.0f) + Mathf.Pow(agent.velocity.z, 2.0f))).ToString() + " km/h";
        if (x_val > agent.nextPosition.x)
        {
            if (prev != 1)
            {
                Debug.Log("LEFT");
                left_marker.SetActive(true);
                right_marker.SetActive(false);
                straight_marker.SetActive(false);
                prev = 1;
            }
        }
        else if (x_val < agent.nextPosition.x)
        {
            if (prev != 2)
            {
                Debug.Log("RIGHT");
                left_marker.SetActive(false);
                right_marker.SetActive(true);
                straight_marker.SetActive(false);
                prev = 2;
            }
        }
        else if (x_val == agent.nextPosition.x)
        {
            if (prev != 0)
            {
                Debug.Log("STRAIGHT");
                left_marker.SetActive(false);
                right_marker.SetActive(false);
                straight_marker.SetActive(true);
                prev = 0;
            }
        }
        x_val = agent.nextPosition.x;
    }
}
