using UnityEngine;
using System.Collections.Generic;

public abstract class Piece : MonoBehaviour {

    protected bool isSelected = false;
    protected abstract List<MoveSet> MoveSet { get; set; }
    public abstract Enums.colors color { get; set; }

    protected SquareScript currentPosition;

    protected bool IsSelected() 
    {
        return isSelected;
    }

    protected virtual void MakeMove() 
    {
        
    }

    
}
