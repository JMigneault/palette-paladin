using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTracker : MonoBehaviour {

    private int currentWave = 1;
    public int CurrentWave { get { return currentWave; } }
    private float sliderSpeed;
    public float SliderSpeed { get; set; }

    public void NextWave ()
    {
        currentWave++;
    }

}
