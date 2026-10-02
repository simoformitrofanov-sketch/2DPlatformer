using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action JumpPressed;

    public float Horizontal { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)) 
            JumpPressed?.Invoke();
    }
}