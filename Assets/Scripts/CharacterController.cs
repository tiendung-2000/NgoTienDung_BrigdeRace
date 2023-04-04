using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Transform posAddBricks;

    public List<Transform> listBrickCharater = new List<Transform>();

    // public Transform CharacterRenderer;

    public Material[] characterMat;


    public ColorType characterColor;


    public BrickGenerator brickGenerator;



    public LayerMask layerStair;


    public Transform PosRaycast;

    public static List<int> temp = new List<int>();

    public int Rand;


    private void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        CharacterMoving();
    }


    protected virtual void CharacterMoving()
    {
        
    }


    public virtual void RandomCharacterColor(Transform CharacterRenderer, ColorType colorType)
    {
        characterColor = colorType;
        CharacterRenderer.GetComponent<MeshRenderer>().material = characterMat[(int)colorType];
    }

    int QuantityBrick = 0;
    protected virtual void AddBrick(Collider other)
    {
        QuantityBrick++;

        other.transform.SetParent(posAddBricks.transform);

        listBrickCharater.Add(other.transform);

        other.transform.localPosition = new Vector3(0, 0.25f * QuantityBrick, 0);
        other.transform.localRotation = Quaternion.identity;
    }

    protected virtual void RemoveBrick()
    {
        if (listBrickCharater.Count > 0)
        {
            QuantityBrick--;
            Transform lastChild = listBrickCharater[listBrickCharater.Count - 1];
            listBrickCharater.Remove(lastChild.transform);

            Destroy(lastChild.gameObject);
            brickGenerator.GenerateRemovedBrick();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("brick") && characterColor == other.GetComponent<Brick>().brickColor)
        {
            AddBrick(other);

            if (brickGenerator != null)
                brickGenerator.MakeRemoved(other.GetComponent<Brick>().numberBrick);
        }

        if (other.gameObject.CompareTag("finishgame"))
        {
            print("finish game");
        }
    }
    protected virtual Stair CheckLayerStair()
    {
        Debug.DrawLine(PosRaycast.position, PosRaycast.position + Vector3.down, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(PosRaycast.position + Vector3.up, Vector3.down, out hit, Mathf.Infinity, layerStair))
        {
            if (hit.collider != null)
            {
                return hit.collider.GetComponent<Stair>();
            }
        }
        return null;
    }
}
