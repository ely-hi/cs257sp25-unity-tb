using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;

    private Vector2 movementValue;
    private float lookValue;
    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputValue value) {
        movementValue = value.Get<Vector2>() * speed;
    }

     public void OnLook(InputValue value) {
        lookValue = value.Get<Vector2>().x * rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        // {
        // transform.Translate(0, 0, speed * Time.deltaTime);
        // }

        // if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
        // {
        // transform.Translate(0, 0, -speed * Time.deltaTime);
        // }

        // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        // {
        // transform.Translate(-speed * Time.deltaTime, 0, 0);
        // }

        // if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        // {
        // transform.Translate(speed * Time.deltaTime, 0, 0);
        // }

        // float mouseX = Input.GetAxis("Mouse X");
        // transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);

        transform.Translate(
            movementValue.x * Time.deltaTime, 
            0,
            movementValue.y * Time.deltaTime);

        transform.Rotate(0, lookValue * Time.deltaTime, 0);
    }
}
