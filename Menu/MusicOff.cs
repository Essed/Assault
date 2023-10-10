using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOff : MonoBehaviour {

    public AudioClip[] SoundTracks;
    private AudioSource MenuMusic; 

    private void Start()
    {
        MenuMusic = GameObject.Find("Statuette").GetComponent<AudioSource>();

        if (PlayerPrefs.GetString("Music") == "yes")
            PlayMuseMenu();
    }

	private void FixedUpdate ()
    {
        MenuMuse();
        
	}

    private void MenuMuse()
    {
        if (PlayerPrefs.GetString("Music") == "yes")
            MenuMusic.volume = 1f;

        else MenuMusic.volume = 0f;
    }

    private void PlayMuseMenu()
    {
        int RandInd = Random.Range(0,SoundTracks.Length);

        MenuMusic.PlayOneShot(SoundTracks[RandInd]);
    }

}
