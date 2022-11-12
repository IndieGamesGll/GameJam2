using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSound : MonoBehaviour
{
    [SerializeField] AudioSource[] _sounds;
    [SerializeField] GameObject _pauseBut;
    void Start()
    {
        _pauseBut.SetActive(false);
        for (int i = 0; i < _sounds.Length; i++)
        {
            _sounds[i].Stop();
        }


    }


}
