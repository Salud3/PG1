using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class FlaurosCenter : MonoBehaviour
{
    public Material material;
    Vector3[] vertices =
    {
        new Vector3(0,      -(Mathf.Sqrt(6)/3)/2 ,   0                          -0.5773507f ),//0
        new Vector3(0.5f,   -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//1
        new Vector3(-0.5f,  -(Mathf.Sqrt(6)/3)/2 ,   Mathf.Sqrt(3)/2            -0.5773507f ),//2                     
        new Vector3(0,      (Mathf.Sqrt(6)/3)/2 ,   (Mathf.Sqrt(3)/2)+.2886756f-0.5773507f ),//3
        new Vector3(0.5f,   (Mathf.Sqrt(6)/3)/2 ,   .2886756f                  -0.5773507f ),//4
        new Vector3(-0.5f,  (Mathf.Sqrt(6)/3)/2 ,   .2886756f                  -0.5773507f )//5

        /*
        //V2
        new Vector3(0,      -(Mathf.Sqrt(6)/3)/2,       -.5773502691896f),//0
        new Vector3(0.5f,   -(Mathf.Sqrt(6)/3)/2,       Mathf.Sqrt(3)/6),//1
        new Vector3(-0.5f,  -(Mathf.Sqrt(6)/3)/2,        Mathf.Sqrt(3)/6),//2

        new Vector3(0,      Mathf.Sqrt(6)/3/2,       -.5773502691896f),//0
        new Vector3(0.5f,   Mathf.Sqrt(6)/3/2,       (Mathf.Sqrt(3)/6) +.5773502691896f),//1
        new Vector3(-0.5f,  Mathf.Sqrt(6)/3/2,       (Mathf.Sqrt(3)/6) +.5773502691896f),//2
        */


    };

    int[] triangles = {0,1,2,//check //0
                       3,4,5,//check
                       0,4,1,//check
                       2,5,0,//check
                       1,4,3,//check
                       1,3,2,//check
                       2,3,5,//check
                       0,5,4//check
    };
    void FlauroCenter()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.Optimize();
        mesh.RecalculateNormals();

    }
    void Awake()
    {
        FlauroCenter();
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }
    public void Rotate()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);

    }
}
