using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeController : MonoBehaviour
{
    public Vector2 Movement;
    public float Speed;
    private Rigidbody RB;
    private Animator Anim;
    public float RotationSpeed;
    public Transform Graphic;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Anim = GameObject.FindGameObjectWithTag("Graphic").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector3(Movement.x, 0, Movement.y) * Speed;
        Rotate();
        AnimatePlayer();
    }

    void Rotate()
    {
        Vector3 RotationDirection = new Vector3(Movement.x, 0, Movement.y);
        RotationDirection.Normalize();

        if (RotationDirection != Vector3.zero)
        {
            //transform.forward = RotationDirection;
            Quaternion LookDirection = Quaternion.LookRotation(RotationDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, LookDirection, RotationSpeed * Time.deltaTime);
        }

    }

    void AnimatePlayer()
    {
        if (Movement.x != 0 || Movement.y != 0)
        {
            Anim.SetBool("IsRunning", true);
        }
        else if (Movement.x == 0 && Movement.y == 0)
        {
            Anim.SetBool("IsRunning", false);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }
}
