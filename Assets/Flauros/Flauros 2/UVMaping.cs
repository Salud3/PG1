using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class UVMapping : MonoBehaviour
{
    public Material material;
    public float size = 1f;
    void Start()
    {

        Vector3[] vertices = {
            new Vector3(0, size, 0),        //0
            new Vector3(0, 0, 0),           //1
            new Vector3(size, size, 0),     //2
            new Vector3(size, 0, 0),        //3
                                            //
            new Vector3(0, 0, size),        //4
            new Vector3(size, 0, size),     //5
            new Vector3(0, size, size),     //6
            new Vector3(size, size, size),  //7
                                            //
            new Vector3(0, size, 0),        //8
            new Vector3(size, size, 0),     //9
                                            //
            new Vector3(0, size, 0),        //10
            new Vector3(0, size, size),     //11
                                            //
            new Vector3(size, size, 0),     //12
            new Vector3(size, size, size),  //13
        };

        int[] triangles = {
            0, 2, 1, // front
			1, 2, 3,
            4, 5, 6, // back
			5, 7, 6,
            6, 7, 8, //top
			7, 9 ,8,
            1, 3, 4, //bottom
			3, 5, 4,
            1, 11,10,// left
			1, 4, 11,
            3, 12, 5,//right
			5, 12, 13


        };


        Vector2[] uvs = {
            new Vector2(0, 0.66f),
            new Vector2(0.25f, 0.66f),
            new Vector2(0, 0.33f),
            new Vector2(0.25f, 0.33f),

            new Vector2(0.5f, 0.66f),
            new Vector2(0.5f, 0.33f),
            new Vector2(0.75f, 0.66f),
            new Vector2(0.75f, 0.33f),

            new Vector2(1, 0.66f),
            new Vector2(1, 0.33f),

            new Vector2(0.25f, 1),
            new Vector2(0.5f, 1),

            new Vector2(0.25f, 0),
            new Vector2(0.5f, 0),
        };

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();
    }
}