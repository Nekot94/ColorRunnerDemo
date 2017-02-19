using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {


    public Color[] colors;

    private Material boxMaterial;

 
    private BoxStates state;

    public BoxStates State {
        get {
            return state;
        }
        set {
            state = value;
            CheckState();
        } }

    // Use this for initialization
    void Start () {
        boxMaterial = GetComponent<Renderer>().material;
        RandomState();
	}
	
    public void RandomState() {
        int BoxStatesCount = System.Enum.GetNames(typeof(BoxStates)).Length;
        State = (BoxStates)Random.Range(0, BoxStatesCount);
    }

    private void CheckState() {
        Debug.Log(123);
        if (State == BoxStates.green)
            ChangeToGreen();
        else if (State == BoxStates.red)
            ChangeToRed();
        else if (State == BoxStates.blue)
            ChangeToBlue();
    }

    private void ChangeToGreen() {
        ChangeColor(colors[0]);
        float randTime = Random.Range(1f, 30f);
        StartCoroutine(TurnBlue(randTime));
    }


    private void ChangeToRed() {
        ChangeColor(colors[1]);
    }


    private void ChangeToBlue() {
        ChangeColor(colors[2]);
        StartCoroutine(GoBack(2f));
    }


    private void ChangeColor(Color color) {
        boxMaterial.color = color;
        boxMaterial.SetColor("_EmissionColor", color);
    }

   private IEnumerator TurnBlue(float time) {
        yield return new WaitForSeconds(time);
        State = BoxStates.blue;
    }

    private IEnumerator GoBack(float time) {
        yield return new WaitForSeconds(time);
        State--;
    }

    private void OnMouseDown() {
        if ((int)State != 0) {
            State--;
        }
        else {
            State++;
        }
            
    }
}
