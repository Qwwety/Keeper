using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderComponent : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    private Slider VolumeSlider;

    private void Start()
    {
            VolumeSlider = GetComponent<Slider>();
        
    }

    // Update is called once per frame
   
    
    private void Update()
    {
        AudioSource.volume = VolumeSlider.value;
    }
}
