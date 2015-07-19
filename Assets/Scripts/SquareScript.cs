using UnityEngine;
using System.Collections;

public class SquareScript : MonoBehaviour {

    public string squareName;

    private Transform squareGraphic;

    private Renderer squareGraphicRenderer;

    public GameObject SquareAbove;
    public GameObject SquareRight;
    public GameObject SquareBelow;
    public GameObject SquareLeft;

    /**
     * Each square knows what square is above, to the right, below and left of it
     * They know this so we can compare moves against the squares
     * */

	// Use this for initialization
	void Start () {

	}

    void Awake()
    {
        squareGraphic = transform.FindChild("SquareGraphic");

        squareGraphicRenderer = squareGraphic.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetMaterial(Material mat)
    {
        squareGraphicRenderer.material = mat;
    }

    public Material GetMaterial()
    {
        return squareGraphicRenderer.material;
    }

}
