using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class setting_menu : MonoBehaviour
{
        public AudioMixer audioMixer;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);//Mathf.Log10(volume) * 20);
    }
    public void fullscreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }
}
