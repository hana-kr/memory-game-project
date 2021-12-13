using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{

    public UnityEvent Button;

    void Awake()
    {
        Button = new UnityEvent();
       
    }
}