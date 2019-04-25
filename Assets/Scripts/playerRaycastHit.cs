using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycastHit : MonoBehaviour
{
	Camera cam;
	Ray ray;
    RaycastHit hit;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0));
        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        if(Physics.Raycast(ray, out hit))
	    {
            //print (hit.collider.name);
            if (Input.GetMouseButtonDown(0)) {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = player.GetComponent<playerColors>().getColor();
                hit.collider.gameObject.tag = "colouredObject";
            }
        }
    }
}
