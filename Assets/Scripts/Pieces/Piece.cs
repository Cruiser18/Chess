using UnityEngine;
using System.Collections;

public abstract class Piece : MonoBehaviour {

    protected bool isSelected = false;

    protected SquareScript currentPosition;

    protected bool IsSelected() 
    {
        return isSelected;
    }

    protected virtual void MakeMove() 
    {
        
    }

    protected virtual bool IsMoveValid()
    {
        return false;
    }
}
