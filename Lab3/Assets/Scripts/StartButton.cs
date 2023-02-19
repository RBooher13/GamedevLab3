using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour


{
public void OnButtonPress(){
        GameManager.Instance.StartGame();
        print("Button clicked");
    }

}