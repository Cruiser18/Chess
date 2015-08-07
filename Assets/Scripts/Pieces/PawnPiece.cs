using UnityEngine;
using System.Collections.Generic;

public class PawnPiece : Piece {

    protected override List<MoveSet> MoveSet { get; set; }

    public override Enums.colors color { get; set; }
    
}
