using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var audioSource = this.transform.GetChild(0).GetComponent<AudioSource>();
        audioSource.PlayDelayed(0.5f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
