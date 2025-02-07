using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{

    public GameObject prefab;
    public GameObject shootPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void OnFire(InputValue value)
    {
        if (value.isPressed) {
            GameObject clone = Instantiate(prefab);

            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
        }
    }
     // Update is called once per frame
    void Update()
    {

    }
}
