using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    private Camera mainCamera;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        Vector3 playerRotation = player.transform.transform.eulerAngles;
        mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y+2.0f, playerInfo.z+1.0f);
        mainCamera.transform.transform.eulerAngles= new Vector3(0.0f, playerRotation.y, 0.0f);
    }
}
