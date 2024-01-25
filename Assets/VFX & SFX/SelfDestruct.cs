using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Clone destroy me")
        {
            Destroy(gameObject, 2f);
        }
    }
}
