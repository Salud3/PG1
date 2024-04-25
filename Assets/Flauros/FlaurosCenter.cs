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
        new Vector3(0,0,0),//0
        new Vector3(0.5f, 0 ,Mathf.Sqrt(3)/2),//1
        new Vector3(-0.5f, 0 ,Mathf.Sqrt(3)/2),//2

        new Vector3(0, Mathf.Sqrt(6)/3, (Mathf.Sqrt(3)/2)+.2886756f),//3
        new Vector3(0.5f, Mathf.Sqrt(6)/3, .2886756f),//4
        new Vector3(-0.5f, Mathf.Sqrt(6)/3,.2886756f)//5


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
    void Start()
    {
        FlauroCenter();
        transform.rotation = new Quaternion(0, 180, 0, 0);

    }
}
