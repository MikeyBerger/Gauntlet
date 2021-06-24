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
        CC = GetComponentInParent<CubeController>();
        Mat = GetComponent<Material>();
        MR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CC.IsShielding == true)
        {
            MR.enabled = true;
            CC.Speed = 0;
        }
        else if (CC.IsShielding == false)
        {
            MR.enabled = false;
            CC.Speed = 5;
        }

        if (CC.PI.playerIndex == 0 && CC.gameObject.CompareTag("Player1"))
        {
            //Mat.color = Color.red;
            MR.material.color = Color.red;
        }
        else if (CC.PI.playerIndex == 1 && CC.gameObject.CompareTag("Player2"))
        {
            MR.material.color = Color.blue;
        }
        else if (CC.PI.playerIndex == 2 && CC.gameObject.CompareTag("Player3"))
        {
            MR.material.color = Color.green;
        }
        else if (CC.PI.playerIndex == 3 && CC.gameObject.CompareTag("Player4"))
        {
            MR.material.color = Color.yellow;
        }
    }
}
