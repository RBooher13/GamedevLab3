using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Robot : MonoBehaviour

{
    public string text;
    public AudioSource audio;

    public void OnTriggerEnter2D(Collider2D collider2D) {
        StartCoroutine("Beep");
        StopCoroutine("Beep");
        print("Entered..");
        if (collider2D.gameObject.CompareTag("Player")) {
            GameManager.Instance.DialogShow(text);
        }
    }
    public void OnTriggerExit2D(Collider2D collider2D) {
        if (collider2D.gameObject.CompareTag("Player")) {
            GameManager.Instance.DialogHide();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Beep()
    {
        audio.Play();
        yield return new WaitForSeconds(0.1f);
        audio.Pause();
        // https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
    }
}
