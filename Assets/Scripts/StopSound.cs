using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSound : MonoBehaviour
{
    [SerializeField] AudioSource[] _sounds;
    void Start()
    {
        for (int i = 0; i < _sounds.Length; i++)
        {
            _sounds[i].Stop();
        }


    }


}
