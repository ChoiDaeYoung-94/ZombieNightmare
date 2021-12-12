using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

// HTC VIVE의 Controller를 사용할 때 Controller의 어느 버튼을 사용하는지를 알려주기 위함
public class ViveInputManager : MonoBehaviour
{
    public SteamVR_Input_Sources handType;

    public SteamVR_Action_Boolean grabAction;

    public bool gunRight = false;
    public bool gunLeft = false;

    void Update()
    {
        if (grabAction.GetState(handType) && handType == SteamVR_Input_Sources.RightHand)
            gunRight = true;

        if (grabAction.GetState(handType) && handType == SteamVR_Input_Sources.LeftHand)
            gunLeft = true;

        if (grabAction.GetStateUp(handType) && handType == SteamVR_Input_Sources.RightHand)
            gunRight = false;

        if (grabAction.GetStateUp(handType) && handType == SteamVR_Input_Sources.LeftHand)
            gunLeft = false;
    }
}
