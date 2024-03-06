using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_Destruct : MonoBehaviour
{
    private GameObject selfDestructCheck;


    private void Awake()
    {
        selfDestructCheck = GameObject.FindGameObjectWithTag("SelfDestruct");
    }

    private void LateUpdate()
    {
        SelfDestruct();
    }


    public void SelfDestruct()
    {
        if (this.gameObject.transform.position.y < selfDestructCheck.transform.position.y)
         {
             Destroy(this.gameObject, 3f);
         }
    }
}
