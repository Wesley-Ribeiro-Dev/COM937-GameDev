using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
   private void OnEnable()
   {
      FindObjectOfType<AudioManager>().SetVolumeSlider(gameObject.GetComponent<Slider>());
   }
}
