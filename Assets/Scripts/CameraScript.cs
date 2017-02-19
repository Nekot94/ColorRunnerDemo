using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public static float offsetX;

    [SerializeField]
    GameObject Player;

	// Use this for initialization
	void Start () {
        Debug.Log(Screen.width);
        offsetX = Player.transform.localScale.x * 8;
    }
	
	// Update is called once per frame
	void Update () {
        MoveTheCamera();
	}

    void MoveTheCamera() {
        Vector3 temp = transform.position;
        temp.x = Player.transform.position.x + offsetX;
        transform.position = temp; 
    }
}
