using System.Collections;
using System.Collections.Generic;
using Gvr.Internal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFollowCamera : MonoBehaviour
{
    public GameObject gvrControllerMain_;
    // public GvrControllerMain gvrControllerMain_;
    // Start is called before the first frame update
    void Start()
    {
        gvrControllerMain_ = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrControllerMain_ == null)
            gvrControllerMain_ = GameObject.Find("GvrControllerMain");
        
        Debug.Log(gvrControllerMain_.GetComponent<Transform>().localRotation);
        // Debug.Log(GvrControllerInput.GetDevice(GvrControllerHand.Dominant).Orientation);
    }
}
