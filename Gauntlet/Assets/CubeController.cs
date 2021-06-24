using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeController : MonoBehaviour
{
    public Vector2 Movement;
    public float Speed;
    public float DashPower;
    private Rigidbody RB;
    private Animator Anim;
    public float RotationSpeed;
    //private Transform Graphic;
    //public Material Mesh;
    public PlayerInput PI;
    public bool IsDashing;
    public bool IsShielding;


    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(2);
        IsDashing = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Anim = GameObject.FindGameObjectWithTag("Graphic").GetComponentInChildren<Animator>();
        //Anim = GetComponentInChildren<Animator>(); 
        PI = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDashing && !IsShielding)
        {
            RB.velocity = new Vector3(Movement.x, 0, Movement.y) * Speed;
        }

        Rotate();
        AnimatePlayer();
        //PlayerColor();
        ChangeTag();

        if (IsDashing)
        {
            transform.Translate(new Vector3(Movement.x, 0, Movement.y) * DashPower * Time.deltaTime);
            //RB.AddForce(new Vector3(Movement.x, 0, Movement.y) * DashPower * Time.deltaTime);
            //IsDashing = false;
        }

        if (IsDashing && Movement.x == 0 && Movement.y == 0)
        {
            //transform.Translate(new Vector3(0,0,transform.rotation.y) * DashPower * Time.deltaTime);
            //RB.AddForce(Vector3.forward * DashPower * Time.deltaTime);
            //IsDashing = false;
            //StartCoroutine(StopDash());
        }

        if (IsShielding)
        {
            RB.velocity = Vector3.zero * 0;
            Speed = 0;
            //RB.transform.forward = Vector3.zero;
            RB.isKinematic = true;
        }
        else if (!IsShielding)
        {
            RB.isKinematic = false;
        }

    }

    void Rotate()
    {
        Vector3 RotationDirection = new Vector3(Movement.x, 0, Movement.y);
        Vector3 NoRotation = new Vector3(0, 0, 0);
        RotationDirection.Normalize();

        if (RotationDirection != Vector3.zero)
        {
            //transform.forward = RotationDirection * Time.deltaTime ;
            Quaternion LookDirection = Quaternion.LookRotation(RotationDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, LookDirection, RotationSpeed * Time.deltaTime);
        }

        /*
        if (RotationDirection == Vector3.zero)
        {
            Quaternion StopLook = Quaternion.LookRotation(RotationDirection);
            transform.rotation = transform.rotation = Quaternion.RotateTowards(transform.rotation, StopLook, 0 * Time.deltaTime);
        }
        */
    }

    void AnimatePlayer()
    {
        if (Movement.x == 0 && Movement.y == 0)
        {
            Anim.SetBool("IsRunning", false);

        }
        else if (Movement.x != 0 || Movement.y != 0)
        {
            Anim.SetBool("IsRunning", true);
        }

        if (IsDashing)
        {
            Anim.SetBool("IsRunning", true);
            //RB.AddForce(Vector3.forward * DashPower * Time.deltaTime);
        }
        else if (!IsDashing)
        {
            Anim.SetBool("IsRunning", false);
        }
    }

    void PlayerColor()
    {
        //Mesh.color = Color.red;
    }

    void ChangeTag()
    {
        if (PI.playerIndex == 0)
        {
            transform.gameObject.tag = "Player1";
        }
        else if (PI.playerIndex == 1)
        {
            transform.gameObject.tag = "Player2";
        }
        else if (PI.playerIndex == 2)
        {
            transform.gameObject.tag = "Player3";
        }
        else if (PI.playerIndex == 3)
        {
            transform.gameObject.tag = "Player4";
        }
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

    public void OnShield(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsShielding = true;
        }

        if (ctx.phase == InputActionPhase.Canceled)
        {
            IsShielding = false;
        }

    }
}
