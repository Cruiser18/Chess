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

    void Awake()
    {
        squareGraphic = transform.FindChild("SquareGraphic");

        squareGraphicRenderer = squareGraphic.GetComponent<Renderer>();
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
