using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgAudioSource;
    [SerializeField] private Slider slider;

    private AudioSource audioSource;

    public AudioClip _buttonClick;
    public AudioClip _takeBonus;
    public AudioClip _win;
    public AudioClip _lose;
    public AudioClip _rollDice;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void AudioButtonClick()
    {
        audioSource.clip = _buttonClick;
        audioSource.Play();
    }

    public void AudioTakeBonus()
    {
        audioSource.clip = _takeBonus;
        audioSource.Play();
    }

    public void AudioWin()
    {
        audioSource.clip = _win;
        audioSource.Play();
    }

    public void AudioLose()
    {
        audioSource.clip = _lose;
        audioSource.Play();
    }

    public void AudioRollDice()
    {
        audioSource.clip = _rollDice;
        audioSource.Play();
    }

    public void ChangeAudioValue()
    {
        audioSource.volume = slider.value;
        bgAudioSource.volume = slider.value;
    }

}
