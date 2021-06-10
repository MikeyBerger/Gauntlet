using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private MeshRenderer MR;
    private CubeController CC;
    private Material Mat;

    // Start is called before the first frame update
    void Start()
    {
        MR = GetComponent<MeshRenderer>();
        CC = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<CubeController>();
        Mat = GetComponent<Material>();
        MR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CC.IsShielding == true)
        {
            MR.enabled = true;
        }

        if (CC.PI.playerIndex == 0)
        {
            //Mat.color = Color.red;
            MR.material.color = Color.red;
        }
        else if (CC.PI.playerIndex == 1)
        {
            MR.material.color = Color.blue;
        }
        else if (CC.PI.playerIndex == 2)
        {
            MR.material.color = Color.green;
        }
        else if (CC.PI.playerIndex == 3)
        {
            MR.material.color = Color.yellow;
        }
    }
}
