using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour


{
    public GameObject protag;

    public float x;
    public float y;

    public void startGame() {
        Vector2 pos = protag.transform.position;
        x = -20.6f;
        y = -8.8f;
        protag.transform.position = new Vector2(x, y);
    }
    
}