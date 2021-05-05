using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 Movement;
    public float Speed;
    public float RotationSpeed;
    public float DashPower;
    public float DashTimer;
    private Rigidbody RB;
    private Animator Anim;
    public Transform Graphic;
    public bool IsDashing;

    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(DashTimer);
        transform.position = Vector3.zero;
        IsDashing = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Anim = GameObject.FindGameObjectWithTag("Graphic").GetComponent<Animator>();
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

        if (IsDashing && Movement.x != 0 || Movement.y != 0)
        {
            RB.AddForce(new Vector3(Movement.x * DashPower ,0, Movement.y * DashPower));
            //StartCoroutine(StopDash());
            IsDashing = false;
        }
        else if(IsDashing && Movement.x == 0 && Movement.y == 0)
        {
            transform.Translate(0, 0, DashPower);
            //RB.AddForce(new Vector3(Graphic.rotation.x, 0, Graphic. rotation.z) * DashPower);
            IsDashing = false;
        }
        //transform.Rotate(new Vector3(Movement.x, 0, Movement.y));
        Rotate(); //Calls the "Rotate" function
        
    }

    //Rotates the player to the direction he is moving towards (DO NOT CHANGE UNLESS NECESSARY)
    void Rotate()
    {
        Vector3 RotationDirection = new Vector3(Movement.x, 0, Movement.y);
        RotationDirection.Normalize();

        if (RotationDirection != Vector3.zero)
        {
            Graphic.transform.forward = RotationDirection;
            //Quaternion LookDirection = Quaternion.LookRotation(RotationDirection, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, LookDirection, RotationSpeed * Time.deltaTime);
        }

        transform.rotation = Graphic.transform.rotation;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsDashing = true;
        }
    }
}
