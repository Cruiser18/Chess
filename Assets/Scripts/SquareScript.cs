using UnityEngine;
using System.Collections;

public class SquareScript : MonoBehaviour {

    public string squareName;

    private Transform squareGraphic;

    private Renderer squareGraphicRenderer;

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
