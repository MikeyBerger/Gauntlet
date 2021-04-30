using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 Movement;
    public float Speed;
    public float RotationSpeed;
    private Rigidbody RB;
    private Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement.Normalize();
        if (Movement.x > 0 || Movement.x < 0 || Movement.y > 0 || Movement.y < 0)
        {
            //RB.velocity = new Vector3(Movement.x, 0, Movement.y) * Speed;
            Anim.SetBool("IsRunning", true);
            transform.Translate(new Vector3(Movement.x, 0, Movement.y) * Speed * Time.deltaTime);
        }
        else if(Movement.x == 0 && Movement.y == 0)
        {
            Anim.SetBool("IsRunning", false);
            transform.Translate(Vector3.zero);
        }
        //transform.Rotate(new Vector3(Movement.x, 0, Movement.y));
        Rotate();
        
    }

    void Rotate()
    {
        Vector3 RotationDirection = new Vector3(Movement.x, 0, Movement.y);
        RotationDirection.Normalize();

        if (RotationDirection != Vector3.zero)
        {
            transform.forward = RotationDirection;
            //Quaternion LookDirection = Quaternion.LookRotation(RotationDirection, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, LookDirection, RotationSpeed * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }
}
