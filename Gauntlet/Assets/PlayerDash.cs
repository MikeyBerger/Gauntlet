using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private CubeController CC;
    private Rigidbody RB;
    public float DashPower;
    public float Timer;
    //public float Limit;


    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(Timer);
        CC.IsDashing = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        CC = GetComponent<CubeController>();
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CC.IsDashing && CC.Movement.x != 0 || CC.Movement.y != 0)
        {
            RB.AddForce(new Vector3(CC.Movement.x, 0, CC.Movement.y) * Time.deltaTime * DashPower);
            StartCoroutine(StopDash());
        }
    }
}
