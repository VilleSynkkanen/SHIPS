using UnityEngine;


public enum FadeType { clipSwitch, sceneSwitch };
public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance = null;
    [SerializeField] AudioSource music;
    [SerializeField] float[] fadeSpeed;
    int fading; // -1, 0 or 1
    float startVolume;

    public AudioSource Music { get => music; }
    public float[] FadeSpeed { get => fadeSpeed; }
    protected int fadeIndex;   // 0 = clip switch, 1 = scene switch;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        startVolume = Music.volume;
    }

    public void FadeMusic(int outOrIn, FadeType type)
    {
        fading = outOrIn;
        fadeIndex = (int)type;
    }

    private void Update()
    {
        if (fading != 0)
        {
            Music.volume += startVolume * fading * FadeSpeed[fadeIndex] * Time.deltaTime;
            if(Music.volume == 0)
            {
                fading = 0;
            }
            else if(Music.volume >= startVolume)
            {
                fading = 0;
                Music.volume = startVolume;
            }
        }
    }
}
