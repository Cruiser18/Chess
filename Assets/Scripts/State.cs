using UnityEngine;
using System.Collections;

public abstract class State : ScriptableObject {

    public virtual void Run()
    {
        Debug.Log("State is running");
    }

    protected virtual void InitState()
    {

    }

    protected virtual void EndState()
    {

    }
}
