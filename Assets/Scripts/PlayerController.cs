using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    
    private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Animator anim;

    [SerializeField] private Text value;
    [SerializeField] private Slider slider;
    [SerializeField] private int kgValue;


    private int lineToMove = 1;
    public float LineDistance = 4;
    private float maxSpeed = 20;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        StartCoroutine(SpeedIncrease());
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (kgValue == 120)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (kgValue == 60)
        {
            winPanel.SetActive(true);
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

        slider.value = kgValue;
        if (SwipeController.swipeRight || Input.GetKeyDown(KeyCode.D))
        {
            if (lineToMove < 2)
            {
                lineToMove++;
            }
        }
        if (SwipeController.swipeLeft || Input.GetKeyDown(KeyCode.A))
        {
            if (lineToMove > 0)
            {
                lineToMove--;
            }
        }
        

        

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
        {
            targetPosition += Vector3.left * LineDistance;
        }
        else if (lineToMove == 2)
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
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }
        

    }
    private void FixedUpdate()
    {
        direction.z = speed;
        direction.y += gravity * Time.fixedDeltaTime;
        controller.Move(direction * Time.fixedDeltaTime);
    }
    private void Jump()
    {
        direction.y = jumpForce;
        anim.SetTrigger("Jump");
    }
   
        
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Good")
        {
            kgValue--;
            value.text = kgValue.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Bad")
        {
            kgValue++;
            value.text = kgValue.ToString();
            Destroy(other.gameObject);
        }
    }
    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(4);
        if (speed < maxSpeed)
        {
            speed += 3;
            StartCoroutine(SpeedIncrease());
        }
    }
    private IEnumerator Slide()
    {
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1f;
        anim.SetTrigger("Roll");
        yield return new WaitForSeconds(1);
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
    }
}
