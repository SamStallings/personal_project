using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventBehaviors : MonoBehaviour
{
    public UnityEventBehaviors awakeEvent, startEvent, onEnableEvent;
    public float holdTime;

    private void Awake()
    {
        awakeEvent.Invoke();
    }

    private void Invoke()
    {
        throw new NotImplementedException();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(holdTime);
        startEvent.Invoke();
    }

    private void OnEnable()
    {
        onEnableEvent.Invoke();
    }
}
