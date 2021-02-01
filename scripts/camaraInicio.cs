using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraInicio : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float pos;
    private float sumPos;

    void Start()
    {
        sumPos = 0.3f * Time.deltaTime;
        pos = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        pos = pos + sumPos;
        transform.position = new Vector3(pos, pos, pos);
        if (pos < 3.0f || pos > 13.0f)
        {
            sumPos = sumPos * -1;
        }
    }
}
