using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour {

    [System.Serializable]
    private class Region
    {
        public float xmin;
        public float xmax;        
    }

    [SerializeField] private float speed;
    [SerializeField] private Region sliderRegion;
    [SerializeField] private Region[] attackRegions;

    private int direction = 1;

    private void Update()
    {
        this.SetX(this.transform.position.x + (speed * Time.deltaTime * direction));
        if (this.transform.position.x > sliderRegion.xmax || this.transform.position.x < sliderRegion.xmin)
        {
            TurnAround();
            if (this.transform.position.x > sliderRegion.xmax)
            {
                this.SetX(sliderRegion.xmax);
            }
            if (this.transform.position.x < sliderRegion.xmin)
            {
                this.SetX(sliderRegion.xmin);
            }
        }
    }

    private void Press()
    {

    }

    private void SetX(float x)
    {
        this.transform.position = new Vector2(x, this.transform.position.y);
    }

    private void TurnAround()
    {
        direction *= -1;
    }

}
