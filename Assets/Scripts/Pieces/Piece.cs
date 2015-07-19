using UnityEngine;
using System.Collections.Generic;

public abstract class Piece : MonoBehaviour {

    protected bool isSelected = false;
    protected abstract List<Move> MoveSet { get; set; }

    protected SquareScript currentPosition;

    protected bool IsSelected() 
    {
        return isSelected;
    }

    protected virtual void MakeMove() 
    {
        
    }

    
}
