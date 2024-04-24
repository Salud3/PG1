using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class FlaurosPiramid : MonoBehaviour
{
    public Material material;
    Vector3[] vertices =
    {
        new Vector3(0,0,0),//0
        new Vector3(0.5f,0,Mathf.Sqrt(3)/2),//1
        new Vector3(-0.5f,0,Mathf.Sqrt(3)/2),//2
        new Vector3(0,Mathf.Sqrt(6)/3,.5773502691896f),//3
    };

    int[] triangles = {0,1,2,//check //0
                       0,3,1,//check //1
                       1,3,2,//check //2
                       2,3,0
                       
    };
    void Piramide()
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

    private void Start()
    {
        Piramide();
    }
}
