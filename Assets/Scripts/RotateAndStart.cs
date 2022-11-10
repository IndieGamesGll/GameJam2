using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndStart : MonoBehaviour
{

    [SerializeField] Transform _player;
    [SerializeField] Transform _camera;
    [SerializeField] Animator _animator;
    [SerializeField] PlayerController _playerController;
    [SerializeField] MonoBehaviour _cameraController;
    public void RotateAndGo()
    {
        _cameraController.enabled = true;
        _camera.position = new Vector3(0, 6.19f, -13);
        _camera.rotation = Quaternion.Euler(16.194f,0f,0f);
        _player.Rotate(0, 180, 0);
        _animator.SetBool("Dance", false);
        _playerController._speed = 20f;
    }
}
