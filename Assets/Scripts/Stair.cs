using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    public List<Material> materials;
    public ColorType colorType;
    public void ChangeColor(ColorType color)
    {
        colorType = color;
        GetComponent<MeshRenderer>().material = materials[(int)color];
    }    
}
