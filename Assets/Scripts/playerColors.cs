using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerColors : MonoBehaviour
{
	Color red;
	Color green;
	Color blue;
	Color equipt;

    public GameObject redHighlight;
    public GameObject greenHighlight;
    public GameObject blueHighlight;

    // Start is called before the first frame update
    void Start()
    {
        red = new Color(1f, 0f, 0f, 1f);
        green = new Color(0f, 1f, 0f, 1f);
        blue = new Color(0f, 0f, 1f, 1f);
        equipt = red;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)) {
        	equipt = red;
        }
        if(Input.GetKey(KeyCode.Alpha2)) {
        	equipt = green;
        }
        if(Input.GetKey(KeyCode.Alpha3)) {
        	equipt = blue;
        }

        uiHighlight();
    }

	public Color getColor() {
		return equipt;
	}

    void uiHighlight() {
        if(equipt == red) {
            redHighlight.SetActive(true);
        }
        else {
            redHighlight.SetActive(false);
        }
        if(equipt == green) {
            greenHighlight.SetActive(true);
        }
        else {
            greenHighlight.SetActive(false);
        }
        if(equipt == blue) {
            blueHighlight.SetActive(true);
        }
        else {
            blueHighlight.SetActive(false);
        }
    }
}
