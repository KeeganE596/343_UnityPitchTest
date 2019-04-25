using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaLightLevel : MonoBehaviour
{
	Light lt;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] coloured = GameObject.FindGameObjectsWithTag("colouredObject");
        lt.intensity = (coloured.Length/5);
    }
}
