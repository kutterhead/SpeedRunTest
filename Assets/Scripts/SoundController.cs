using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioClip jumpSound;
    public AudioClip itemSound;
    public AudioClip hitSound;


    private AudioSource fuente;

    void Start()
    {
        fuente = GetComponent<AudioSource>();
        gameController.cajaRecolectada += reproduceItem;
        gameController.vidaPerdida += reproduceError;


    }

    void reproduceJump()
    {
        fuente.clip = jumpSound;
        fuente.Play();
    }
    void reproduceItem()
    {
        fuente.clip = itemSound;
        fuente.Play();
    }
    void reproduceError()
    {
        fuente.clip = hitSound;
        fuente.Play();
    }
}
