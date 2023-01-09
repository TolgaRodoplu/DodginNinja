using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Obstacle : MonoBehaviour
{
    float speed = 0.5f;
    Rigidbody rb;
    bool isEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        EventSystem.instance.gameEnded += Disable;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isEnabled)
            rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
    }

    void Disable(object sender, string str)
    {
        isEnabled = false;
    }
}
