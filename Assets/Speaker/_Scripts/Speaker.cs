using UnityEngine;

public class Speaker : MonoBehaviour
{
    public static Speaker instance;
    public AudioSource sfx;

    public void PlaySfxClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(sfx, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }

    private void Awake()
    {
        if (instance == null)
            instance = this; 
    }
}
