using UnityEngine;
using System.Collections;

public class BoardScript : MonoBehaviour {

    private GameObject[,] boardSquares = new GameObject[8, 8];
    public GameObject squarePrefab;
    public Material whiteSquareMaterial;
    public Material blackSquareMaterial;

    private string[] squareHorizontalNames = { "a", "b", "c", "d", "e", "f", "g", "h", };
    private string[] squareVerticalNames = { "1", "2", "3", "4", "5", "6", "7", "8", };

	// Use this for initialization
	void Start () {

        CreateGameBoard();

        PlacePieces();
	}

	// Update is called once per frame
	void Update () {
	
	}

    private void CreateGameBoard()
    {
        int i, j;

        for (i = 0; i < 8; i++)
        {
            for (j = 0; j < 8; j++)
            {
                GameObject square = GameObject.Instantiate(squarePrefab, this.transform.position + (new Vector3(1, 0, 0) * i) + (new Vector3(0, 0, 1) * j), Quaternion.identity) as GameObject;

                square.transform.SetParent(this.transform);

                boardSquares[i, j] = square;

                square.name = squareHorizontalNames[i] + squareVerticalNames[j];

                SquareScript squareScript = square.GetComponent<SquareScript>();


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

    private void PlacePieces()
    {
        // Make the different pieces and place them on the board


    }
}
