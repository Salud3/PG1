using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixMult : MonoBehaviour
{
//  public Vector4 delt = new Vector4(0,0,0,0);
//  public Vector4 pos = new Vector4(0,0,0);

    public float[] delt = { 8, 0, 2, 0 };
    public float[] pos = { 8, 2, 3, 1 };
    public Vector3 result = new Vector3();

    float[,] floats = new float[4,4];

    private void Start()
    {

    }

    public Vector3 Mult(Vector4 position, Vector4 delta)
    {
        float[,] identity= new float[,] { {1,0,0,delta.x },
                                          {0,1,0,delta.y},
                                          {0,0,1,delta.z},
                                          {0,0,0,1},  
        };

        float x = ((identity[0, 0] * position.x) + (identity[0, 1] * position.x) + (identity[0, 2] * position.x) + (identity[0, 3] * position.x));
        float y = ((identity[1, 0] * position.y) + (identity[1, 1] * position.y) + (identity[1, 2] * position.y) + (identity[1, 3] * position.y));
        float z = ((identity[2, 0] * position.z) + (identity[2, 1] * position.z) + (identity[2, 2] * position.z) + (identity[2, 3] * position.z));

        return new Vector3(x, y, z); 
    }



    public Vector3 RotZ(Vector4 position, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;

        float[,] identity = new float[,] {  {Mathf.Cos(rad),  -Mathf.Sin(rad),0,0},
                                            {Mathf.Sin(rad),  Mathf.Cos(rad), 0,0},
                                            {0,               0,              1,0},
                                            {0,               0,              0,1},
        };

        float x = ((identity[0, 0] * position.x) + (identity[0, 1] * position.y) + (identity[0, 2] * position.z) + (identity[0, 3] * 1));
        float y = ((identity[1, 0] * position.x) + (identity[1, 1] * position.y) + (identity[1, 2] * position.z) + (identity[1, 3] * 1));
        float z = ((identity[2, 0] * position.x) + (identity[2, 1] * position.y) + (identity[2, 2] * position.z) + (identity[2, 3] * 1));

        return new Vector3(x, y, z);
    }

    public Vector3 RotX(Vector4 position, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;

        float[,] identity= new float[,] { {1,   0,             0,              0},
                                          {0,   Mathf.Cos(rad),-Mathf.Sin(rad),0},
                                          {0,   Mathf.Sin(rad),Mathf.Cos(rad), 0},
                                          {0,   0,             0,              1},  
        };

        float x = ((identity[0, 0] * position.x) + (identity[0, 1] * position.y) + (identity[0, 2] * position.z) + (identity[0, 3] * 1));
        float y = ((identity[1, 0] * position.x) + (identity[1, 1] * position.y) + (identity[1, 2] * position.z) + (identity[1, 3] * 1));
        float z = ((identity[2, 0] * position.x) + (identity[2, 1] * position.y) + (identity[2, 2] * position.z) + (identity[2, 3] * 1));
        return new Vector3(x, y, z); 
    }

    public Vector3 RotY(Vector4 position, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;

        float[,] identity= new float[,] { {Mathf.Cos(rad),  0,              Mathf.Sin(rad), 0},
                                          {0,               1,              0,              0},
                                          {-Mathf.Sin(rad), 0,              Mathf.Cos(rad), 0},
                                          {0,               0,              0,              1},
        };

        float x = ((identity[0, 0] * position.x) + (identity[0, 1] * position.y) + (identity[0, 2] * position.z) + (identity[0, 3] * 1));
        float y = ((identity[1, 0] * position.x) + (identity[1, 1] * position.y) + (identity[1, 2] * position.z) + (identity[1, 3] * 1));
        float z = ((identity[2, 0] * position.x) + (identity[2, 1] * position.y) + (identity[2, 2] * position.z) + (identity[2, 3] * 1));

        return new Vector3(x, y, z); 
    }
    



    public void Matrixmult()
    {
        for (int i = 0; i < 4; i++)
        {

            for (int j = 0; j < 4; j++)
            {
                if (i == j)
                {
                    floats[i, j] = 1;
                }
                else
                {
                    floats[i, j] = 0;
                }
            }

        }

        floats[0, 3] = delt[0];
        floats[1, 3] = delt[1];
        floats[2, 3] = delt[2];
        delt[3] = 1;


        float temp1 = 0;
        float temp2 = 0;
        float temp3 = 0;
        float temp4 = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                switch (i)
                {
                    case 0:
                        temp1 += floats[i, j] * pos[j];
                        break;
                    case 1:
                        temp2 += floats[i, j] * pos[j];
                        break;
                    case 2:
                        temp3 += floats[i, j] * pos[j];
                        break;
                    case 3:
                        temp4 += floats[i, j] * pos[j];
                        break;
                    default:
                        break;
                }

            }
        }

        result.x = temp1;
        result.y = temp2;
        result.z = temp3;
    }



}
