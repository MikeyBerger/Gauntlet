using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private CubeController CC;
    private Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        CC = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<CubeController>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CC.Movement.x != 0 || CC.Movement.y != 0)
        {
            Anim.SetBool("IsRunning", true);
        }
        else if (CC.Movement.x == 0 && CC.Movement.y == 0)
        {
            Anim.SetBool("IsRunning", false);
        }

        if (CC.IsDashing)
        {
            Anim.SetBool("IsDashing", true);
        }
        else if (!CC.IsDashing)
        {
            Anim.SetBool("IsDashing", false);
        }
    }


}
