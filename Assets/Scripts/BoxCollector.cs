using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollector : MonoBehaviour {

    private GameObject[] boxes;
    private float lastBoxX;

    // Use this for initialization
    void Start () {
        boxes = GameObject.FindGameObjectsWithTag("Box");
        lastBoxX = boxes[0].transform.position.x;

        foreach (GameObject box in boxes)
            if (lastBoxX < box.transform.position.x)
                lastBoxX = box.transform.position.x;

        
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Box") {


            Vector3 temp = other.transform.position;
            float width = other.transform.localScale.x;

            temp.x = lastBoxX + width;

            other.transform.position = temp;

            lastBoxX = temp.x;


            other.GetComponent<BoxScript>().RandomState();
        }
    }


}
