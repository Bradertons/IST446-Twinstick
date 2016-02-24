using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{

    #region Camera Variables

    private GameObject target;

    public GameObject Target
    {

        get { return target; }
        set { target = value; }

    }

    private Vector3 offset;

    public Vector3 Offset
    {

        get { return offset; }
        set { offset = value; }

    }

    #endregion

    void Start()
    {

        InitializePlayerCamera();

	}

    void InitializePlayerCamera()
    {

        this.target = GameObject.FindGameObjectWithTag("Player");
        this.offset = new Vector3(0, 10, -8);

    }

	void LateUpdate()
    {

        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform.position);

	}
}
