using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI volumeTextUI;
    [SerializeField] private AudioMixer mixer;
    public Button mainMenuButton;
    public Button settingsMenuButton;

    public GameObject mainMenu;
    public GameObject settingsMenu;
    const string MIXER_MUSIC = "MusicVolume";
    public Button fullscreenButton;
    private bool isFullscreen = true;
    [SerializeField] private TextMeshProUGUI fullscreenToggleTextUI;

    private void Start()
    {
        Screen.fullScreen = isFullscreen;
        StartingScenes();
        // Add listeners to the buttons
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        settingsMenuButton.onClick.AddListener(LoadSettingsMenu);
        fullscreenButton.onClick.AddListener(ToggleFullscreen);
        // Ensure the volume slider starts with the correct value
        volumeSlider.value = GetMusicVolume();
        UpdateVolumeText(GetMusicVolume());

        // Listen to changes in the slider value
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    private void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen; // Toggle fullscreen state

        // Set the fullscreen mode
        Screen.fullScreen = isFullscreen;

        // Update the button text to reflect the current state
        fullscreenToggleTextUI.text = isFullscreen ? "ON" : "OFF";
    }

    void StartingScenes()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);

    }

    void LoadMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    void LoadSettingsMenu()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    private void OnVolumeSliderChanged(float volume)
    {
        // Update the volume in the Audio Mixer
        SetMusicVolume(volume);

        // Update the displayed percentage
        UpdateVolumeText(volume);
    }

    private void UpdateVolumeText(float volume)
    {
        // Display the volume as a percentage
        volumeTextUI.text = (volume * 100).ToString("0") + "%";
    }

    private float GetMusicVolume()
    {
        float volume;
        mixer.GetFloat(MIXER_MUSIC, out volume);
        return Mathf.Pow(10, volume / 20); // Convert to linear scale
    }

    private void SetMusicVolume(float volume)
    {
        // Convert the linear volume to dB scale and set it in the Audio Mixer
        if (volume <= 0.001f) // Adjust this threshold as needed
        {
            mixer.SetFloat(MIXER_MUSIC, -80); // Mute the audio
        }
        else
        {
            mixer.SetFloat(MIXER_MUSIC, 20 * Mathf.Log10(volume));
        }
    }
}
