using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BoardScript : MonoBehaviour {

    public const int BOARDWIDTH = 8;
    public const int BOARDHEIGHT = 8;

    public GameObject squarePrefab;
    public Material whiteSquareMaterial;
    public Material blackSquareMaterial;
    public GameObject pawnPrefab;
    private GameObject[,] boardSquares = new GameObject[BOARDWIDTH, BOARDHEIGHT];
    private string[] squareHorizontalNames = { "a", "b", "c", "d", "e", "f", "g", "h", };
    private string[] squareVerticalNames = { "1", "2", "3", "4", "5", "6", "7", "8", };
    private List<GameObject> squaresList = new List<GameObject>();
    private List<KeyValuePair<string, Object>> WhitePiecesToPlace;
    private List<GameObject> BoardPieces;
        

	// Use this for initialization
	void Start () {

        BoardPieces = new List<GameObject>();

        CreatePieces();

        CreateGameBoard();

        PlacePieces();
	}

    private void CreatePieces()
    {
        WhitePiecesToPlace = new List<KeyValuePair<string, Object>>() {
            new KeyValuePair<string, Object>("a2", pawnPrefab),
            new KeyValuePair<string, Object>("b2", pawnPrefab),
            new KeyValuePair<string, Object>("c2", pawnPrefab),
            new KeyValuePair<string, Object>("d2", pawnPrefab),
            new KeyValuePair<string, Object>("e2", pawnPrefab),
            new KeyValuePair<string, Object>("f2", pawnPrefab),
            new KeyValuePair<string, Object>("g2", pawnPrefab),
            new KeyValuePair<string, Object>("h2", pawnPrefab)
        };
    }

	// Update is called once per frame
	void Update () {
        
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
                squaresList.Add(square);
            }
        }
    }

    // Shows the valid moves on chessboard when a piece is selected
    protected void ShowValidMoves(Piece piece)
    {

    }

    // Hides valid moves on chessboard when piece is unselected
    protected void HideValidMoves()
    {

    }

    // Takes some moves 
    protected bool IsMoveValid(Piece piece)
    {
        return false;
    }

    /*
    public Dictionary<string, Piece> GetInitialPiecesPlacement()
    {
        return;
    }*/

    private void PlacePieces()
    {
        // Place the white pieces
        foreach (KeyValuePair<string, Object> piece in WhitePiecesToPlace) 
        {
            foreach(GameObject square in squaresList) 
            {
                Vector3 myVector = squaresList.Where(x => x.name == piece.Key).Select(x => x.GetComponent<SquareScript>().transform.position).First();

                GameObject myPiece = Instantiate(piece.Value, myVector, Quaternion.identity) as GameObject;

                myPiece.GetComponent<Piece>().color = Enums.colors.White;

                BoardPieces.Add(myPiece);

                break;
            }
        }

        
    }
}
