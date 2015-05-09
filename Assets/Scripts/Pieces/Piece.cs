using UnityEngine;
using System.Collections;

public abstract class Piece : MonoBehaviour, IPiece {

    protected bool isSelected = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool IsSelected() 
    {
        return isSelected;
    }

    public void MakeMove() 
    {

    }

    public bool IsMoveValid() 
    {
        return false;
    }
}
