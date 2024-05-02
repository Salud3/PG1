using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaurosMaster : MonoBehaviour
{
    [SerializeField] FlaurosPiramid[] piramids = new FlaurosPiramid[4];
    /*[SerializeField] FlaurosPiramid p1;
    [SerializeField] FlaurosPiramid p2;
    [SerializeField] FlaurosPiramid p3;
    [SerializeField] FlaurosPiramid p4;*/
    [SerializeField] FlaurosCenter Flauros;

    public MatrixMult matrix;

    private void Start()
    {
        for (int i = 0; i < piramids.Length; i++)
        {
            piramids[i].transform.parent = Flauros.transform;
        }
        Flauros.Rotate();
        StartCoroutine(Anim1());
    }

    IEnumerator Anim1()
    {
        if (Flauros.transform.position.y <= 1.5)
        {
            Flauros.transform.position = matrix.Move(Flauros.transform.position, new Vector4(0, 0.1f, 0, 0));
            yield return new WaitForSeconds(.1f);
            StartCoroutine(Anim1());
        }
        else
        {
            Debug.Log("Anim1 finished");
            StartCoroutine(Anim2());
        }
    }

    public int it = 0;
    public int itc;
    float altura;
    public float mov;
    IEnumerator Anim2()
    {
        altura = (mov / 3) / itc;
        if (it <= itc)
        {
            float movreal = mov / itc;

            for (int i = 0; i < piramids.Length; i++)
            {
                if (i != piramids.Length - 1)
                {
                    piramids[i].transform.position = matrix.Move(piramids[i].transform.position, new Vector4(movreal, -altura, movreal, 0));
                }
                else
                {
                    piramids[i].transform.position = matrix.Move(piramids[i].transform.position, new Vector4(0, altura, 0, 0));

                }
            }
            yield return new WaitForSeconds(.1f);
            StartCoroutine(Anim2());
            it++;
        }
        else
        {
            Debug.Log("Anim2 finished");
            it = 0;
            StartCoroutine(Anim3());
            //Debug.Log(it);

        }


    }
    [SerializeField] Vector3 rotation1 = new Vector3(100, 90, 0);//1y-//1 ,z-
    [SerializeField] Vector3 rotation2 = new Vector3(0, 90, 100);//1y-//1 ,z-
    [SerializeField] Vector3 rotation3 = new Vector3(240, 180, 0);
    [SerializeField] Vector3 rotation4 = new Vector3(0, 0, 0);//

    IEnumerator Anim3()
    {
        if (it <= itc)
        {
            //Debug.Log(it);
            piramids[0].Rotate(rotation1 / itc, 0);
            piramids[1].Rotate(rotation2 / itc, 1);
            piramids[2].Rotate(rotation3 / itc, 2);
            piramids[3].Rotate(rotation4 / itc, 3);

            yield return new WaitForSeconds(0.1f);
            StartCoroutine(Anim3());
            it++;
            //Debug.Log(it);
        }
        else
        {
            Debug.Log("Anim3 Finished");
            it = 0;
            StartCoroutine(Anim4());
        }
    }

    [SerializeField] Vector3 rotation5 = new Vector3(135, 50, 0);
    [SerializeField] Vector3 rotation6 = new Vector3(500, 450, 500);
    [SerializeField] Vector3 rotation7 = new Vector3(0, 270,0 );

    Vector3 asd = new Vector3(0, 0, 0);
    IEnumerator Anim4()
    {
        if (it <= itc)
        {
            //Debug.Log(it);
            piramids[0].Rotate(-rotation5 / itc,0);
            piramids[1].Rotate(-rotation6 / itc,1);
            piramids[2].Rotate(-rotation3 / itc,2);
            piramids[3].Rotate((rotation7*-1) + new Vector3(0, 90, 0) / itc, 3);

            yield return new WaitForSeconds(0.1f);
            StartCoroutine(Anim4());
            it++;
            //Debug.Log(it);
        }
        else
        {
            piramids[1].RotateBack();

            Debug.Log("Anim4 Finished");
            it=0;
            StartCoroutine(Anim5());
        }
    }

    IEnumerator Anim5()
    {
        altura = -(mov / 3) / itc;
        if (it <= itc)
        {
            float movreal = -mov / itc;

            for (int i = 0; i < piramids.Length; i++)
            {
                if (i != piramids.Length - 1)
                {
                    piramids[i].transform.position = matrix.Move(piramids[i].transform.position, new Vector4(movreal, -altura, movreal, 0));
                }
                else
                {
                    piramids[i].transform.position = matrix.Move(piramids[i].transform.position, new Vector4(0, altura, 0, 0));

                }
            }
            yield return new WaitForSeconds(.1f);
            StartCoroutine(Anim5());
            it++;
        }
        else
        {
            Debug.Log("Anim5Finished");
            it = 0;
            StartCoroutine(Anim6());

        }

    }



    
    IEnumerator Anim6()
    {
        if (Flauros.transform.position.y >= .6)
        {
            Flauros.transform.position = matrix.Move(Flauros.transform.position, new Vector4(0, -0.1f, 0, 0));
            yield return new WaitForSeconds(.1f);
            StartCoroutine(Anim6());
        }
        else
        {
            Debug.Log("Anim6 finished");
        }
    }

}
