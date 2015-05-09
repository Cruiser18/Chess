using UnityEngine;
using System.Collections;

public interface IPiece  {


    bool IsSelected();

    void MakeMove();

    bool IsMoveValid();



}