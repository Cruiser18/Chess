using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

    InputHandler InputHandler;

    public GameObject chessBoard;
    private GameStateMachine stateMachine;

	// Use this for initialization
	void Start () {
       InputHandler = GameObject.Find("Camera").GetComponent<InputHandler>();

       stateMachine = new GameStateMachine();
       stateMachine.ChangeState(new GameStateBlackTurn());
	}
	
	// Update is called once per frame
	void Update () {
        
        GameObject clickedPiece = InputHandler.ClickPiece();
        // TODO Create state machine for inputhandler to deal with mouseclicks at different situations/times.

        stateMachine.Run();
	}
    
}
