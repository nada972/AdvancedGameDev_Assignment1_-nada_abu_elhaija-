using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class P2Drive : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regSpeed = 6f;
    [SerializeField] TMP_Text BText ;

    [SerializeField]  GameObject Lose ;

    void Start()
    {
        BText.gameObject.SetActive(false);
        Lose.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("boost"))
        {
            moveSpeed = boostSpeed;
            Invoke("ResetSpeed",5f);
            BText.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    void ResetSpeed()
    {
        moveSpeed =regSpeed;
        BText.gameObject.SetActive(false);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        //moveSpeed =regSpeed;
        //BText.gameObject.SetActive(false);
        Lose.gameObject.SetActive(true);
        Destroy(gameObject);
    }
    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.upArrowKey.isPressed)
        {
            move = 1f;
        }
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            move = -1f;
        }
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            steer = 1f;
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            steer = -1f;
        }


        float moveAmount = move * moveSpeed *Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount,0);
        transform.Rotate(0, 0, steerAmount);
        
    }
}
