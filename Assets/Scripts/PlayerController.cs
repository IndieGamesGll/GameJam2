using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    private Vector3 _direction;
    [SerializeField] private float _speed;
    //[SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;
   // [SerializeField] private Animator _anim;

    [SerializeField] private Text _value;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _kgValue;


    private int _lineToMove = 1;
    public float LineDistance = 4;
    private float _maxSpeed = 20;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
       // StartCoroutine(SpeedIncrease());
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (_kgValue >= 1)
        {
            _losePanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (_kgValue <= -1)
        {
            _winPanel.SetActive(true);
            Time.timeScale = 0;
        }
        //if (kgValue >= 100)
        //{
        //    anim.SetTrigger("Fat");
        //    Debug.Log("Fat");
        //}
        //if (kgValue < 100)
        //{
        //    anim.SetTrigger("Thin");
        //}

        _slider.value = _kgValue;

        if (SwipeController.swipeRight || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_lineToMove < 2)
            {
                _lineToMove++;
            }
        }
        if (SwipeController.swipeLeft || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_lineToMove > 0)
            {
                _lineToMove--;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (_lineToMove == 0)
        {
            targetPosition += Vector3.left * LineDistance;
        }
        else if (_lineToMove == 2)
        {
            targetPosition += Vector3.right * LineDistance;
        }

        if (transform.position == targetPosition)
        {
            return;
        }
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            _controller.Move(moveDir);
        }
        else
        {
            _controller.Move(diff);
        }
    }
    private void FixedUpdate()
    {
        _direction.z = _speed;
        _direction.y += _gravity * Time.fixedDeltaTime;
        _controller.Move(_direction * Time.fixedDeltaTime);
    }
    //private void Jump()
    //{
    //    _direction.y = _jumpForce;
    //    _anim.SetTrigger("Jump");
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Good")
        {
            _speed += 0.5f;
            _kgValue -= 0.03f;
            _value.text = _kgValue.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bad")
        {
            _speed -= 0.25f;
            _kgValue += 0.03f;
            _value.text = _kgValue.ToString();
            Destroy(other.gameObject);
        }
    }
    //private IEnumerator SpeedIncrease()
    //{
    //    yield return new WaitForSeconds(4);
    //    if (_speed < _maxSpeed)
    //    {
    //        _speed += 3;
    //        StartCoroutine(SpeedIncrease());
    //    }
    //}
    //private IEnumerator Slide()
    //{
    //    _controller.center = new Vector3(0, -0.5f, 0);
    //    _controller.height = 1f;
    //    _anim.SetTrigger("Roll");
    //    yield return new WaitForSeconds(1);
    //    _controller.center = new Vector3(0, 0, 0);
    //    _controller.height = 2;
    //}
}
