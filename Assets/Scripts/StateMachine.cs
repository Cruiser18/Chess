using UnityEngine;
using System.Collections;

public abstract class StateMachine : MonoBehaviour {

    private State currentState;
    private bool isPaused = false;

    public enum States
    {
        GameStateBlackTurn
    };

    public virtual void Run() {

        Debug.Log("Running");

        if (currentState != null && !isPaused)
        {
            currentState.Run();
        }
    }

    public void ChangeState(State newState)
    {
        currentState = newState;
    }

    public State GetCurrentState()
    {
        return currentState;
    }

    public void PauseState()
    {
        isPaused = true;
    }

    public void UnpauseState()
    {
        isPaused = false;
    }
}
