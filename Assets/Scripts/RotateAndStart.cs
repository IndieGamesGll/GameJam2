using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndStart : MonoBehaviour
{

    [SerializeField] Transform _player;
    [SerializeField] Animator _animator;
    [SerializeField] PlayerController _playerController;
    public void RotateAndGo()
    {
        _player.Rotate(0, 180, 0);
        _animator.SetBool("Dance", false);
        _playerController._speed = 20f;
    }
}
