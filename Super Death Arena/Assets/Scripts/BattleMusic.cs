using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusic : MonoBehaviour
{
    [SerializeField] AudioSource speaker;
    float volume;
    // Start is called before the first frame update
    void Start()
    {
        speaker = gameObject.GetComponent<AudioSource>();
        volume = speaker.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator fadeOut(float fadeTime)
    {
        while (speaker.volume > 0)
        {
            speaker.volume -= Time.deltaTime / fadeTime;
            yield return null;
        }
        speaker.Stop();
        speaker.volume = volume;
    }

    public void play()
    {
        speaker.Play();
    }
}
