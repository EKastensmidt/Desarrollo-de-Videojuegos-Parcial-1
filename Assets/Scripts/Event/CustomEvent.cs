using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomEvent : IEvent
{
    protected int _priority;
    public int Priority => _priority;
}
