using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Percentage : MonoBehaviour
{
    public AudioSource audioSource;
    private float length;
    private float time;
    public Text percentage;
    public Slider progress;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        length = audioSource.clip.length;
        time = audioSource.time;
        percentage.text = ((time / length) * 100).ToString("0") + "%";
        progress.value = ((time / length) * 100);
    }
}
