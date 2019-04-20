using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTracker : MonoBehaviour {

    private int currentWave = 1;
    public int CurrentWave { get { return currentWave; } }
    private float sliderSpeed;
    public float SliderSpeed { get; set; }

    private UnityEngine.UI.Text waveDisplay;

    public void NextWave ()
    {
        currentWave++;
    }

    private void Start()
    {
        waveDisplay = GetComponent<UnityEngine.UI.Text>();
    }

    private void Update()
    {
        waveDisplay.text = "Wave: " + this.currentWave;
    }

}
