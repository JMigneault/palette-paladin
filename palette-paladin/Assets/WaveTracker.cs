using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTracker : MonoBehaviour {

    private int currentWave = 1;
    private int wavesCompleted = 0;
    public int CurrentWave { get { return currentWave; } }
    private float sliderSpeed;
    public float SliderSpeed { get; set; }
    [SerializeField] private UnityEngine.UI.Text waveText;

    private void Start()
    {
        waveText.text = "Wave: " + 1;
    }

    public void NextWave()
    {
        currentWave++;
    }

    public void WaveCompleted()
    {
        wavesCompleted++;
        waveText.text = "Wave: " + (wavesCompleted + 1);
    }
}
