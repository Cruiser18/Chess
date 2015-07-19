using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardScript : MonoBehaviour {

    public const int BOARDWIDTH = 8;
    public const int BOARDHEIGHT = 8;

    private GameObject[,] boardSquares = new GameObject[BOARDWIDTH, BOARDHEIGHT];
    public GameObject squarePrefab;
    public Material whiteSquareMaterial;
    public Material blackSquareMaterial;

    private string[] squareHorizontalNames = { "a", "b", "c", "d", "e", "f", "g", "h", };
    private string[] squareVerticalNames = { "1", "2", "3", "4", "5", "6", "7", "8", };
    private string[] squaresList = {
                                       "a1", "b1", "c1", "d1", "e1", "f1", "g1", "h1",
                                       "a2", "b2", "c2", "d2", "e2", "f2", "g2", "h2",
                                       "a3", "b3", "c3", "d3", "e3", "f3", "g3", "h3",
                                       "a4", "b4", "c4", "d4", "e4", "f4", "g4", "h4",
                                       "a5", "b5", "c5", "d5", "e5", "f5", "g5", "h5",
                                       "a6", "b6", "c6", "d6", "e6", "f6", "g6", "h6",
                                       "a7", "b7", "c7", "d7", "e7", "f7", "g7", "h7",
                                       "a8", "b8", "c8", "d8", "e8", "f8", "g8", "h8"
                                   };

    private Dictionary<string, string> piecePlacement = new Dictionary<string, string>()
        {
            {"a1", "whiteRook1"},
            {"b1", "white1"}
        };

    public GameObject[] piecePrefabs;

    public GameObject pawnPrefab;

	// Use this for initialization
	void Start () {

        CreateGameBoard();

        PlacePieces();
	}

	// Update is called once per frame
	void Update () {
        Debug.Log(Enums.pieces.WhiteKing.GetType());
	}

    private void CreateGameBoard()
    {
        int i, j;

        for (i = 0; i < BOARDWIDTH; i++)
        {
            for (j = 0; j < BOARDHEIGHT; j++)
            {
                GameObject square = GameObject.Instantiate(squarePrefab, this.transform.position + (new Vector3(1, 0, 0) * i) + (new Vector3(0, 0, 1) * j), Quaternion.identity) as GameObject;

                square.transform.SetParent(this.transform);

                boardSquares[i, j] = square;

                square.name = squareHorizontalNames[i] + squareVerticalNames[j];

                SquareScript squareScript = square.GetComponent<SquareScript>();

                // Let squares know of their neighbors
                if (j != 0)
                {
                    // Set this Square's squareBelow with previous square
                    squareScript.SquareBelow = boardSquares[i, j - 1];

                    // Set previous square's squareAbove with this square
                    SquareScript previousSquareScript = boardSquares[i, j - 1].GetComponent<SquareScript>();
                    previousSquareScript.SquareAbove = square;
                }
                if (i != 0)
                {
                    // Set this Square's SquareLeft with previous columns square
                    squareScript.SquareLeft = boardSquares[i - 1, j];
                    // Set previous Square's SquareRight to this square
                    SquareScript previousSquareScript = boardSquares[i - 1, j].GetComponent<SquareScript>();
                    previousSquareScript.SquareRight = square;
                }

                // Set material of squares
                if(i % 2 == 0)
                {
                    if (j % 2 == 1)
                    {
                        squareScript.SetMaterial(whiteSquareMaterial);
                    }
                    else
                    {
                        squareScript.SetMaterial(blackSquareMaterial);
                    }
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        squareScript.SetMaterial(whiteSquareMaterial);
                    }
                    else
                    {
                        squareScript.SetMaterial(blackSquareMaterial);
                    }
                }
                
            }
        }
    }

    // Shows the valid moves on chessboard when a piece is selected
    protected void ShowValidMoves()
    {

    }

    // Hides valid moves on chessboard when piece is unselected
    protected void HideValidMoves()
    {

    }

    // Takes some moves 
    protected bool IsMoveValid()
    {
        return false;
    }

    private void SetInitialPiecesPlacement()
    {
        
    }
    /*
    public Dictionary<string, Piece> GetInitialPiecesPlacement()
    {
        return;
    }*/

    private void PlacePieces()
    {
        /**
         *  Iterate over list of board tiles
         *  Compare each tile against list of where pieces should be placed
         *  Place piece on tile and set piece color as well as position
         * */
        // Make the different pieces and place them on the board
        //Dictionary<string, Piece> piecePlacement = new Dictionary<string, Piece>();

        //piecePlacement.Add("a1", new PawnPiece());

        GameObject piece = Instantiate(pawnPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    }
}
