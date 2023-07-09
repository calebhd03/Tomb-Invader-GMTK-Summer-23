using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip egyptSong;
    [SerializeField] AudioSource audioSource;

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
            audioSource.clip = egyptSong;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
