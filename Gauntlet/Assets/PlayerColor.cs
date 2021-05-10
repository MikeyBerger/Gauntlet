using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    private Material Mat;
    private CubeController CC;
    private SkinnedMeshRenderer SMR;

    // Start is called before the first frame update
    void Start()
    {
        Mat = GetComponent<Material>();
        CC = GetComponentInParent<CubeController>();
        SMR = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CC.PI.playerIndex == 0)
        {
            //Mat.color = Color.red;
            SMR.material.color = Color.red;
        }
        else if (CC.PI.playerIndex == 1)
        {
            SMR.material.color = Color.blue;
        }
        else if (CC.PI.playerIndex == 2)
        {
            SMR.material.color = Color.green;
        }
        else if (CC.PI.playerIndex == 3)
        {
            SMR.material.color = Color.yellow;
        }
    }
}
