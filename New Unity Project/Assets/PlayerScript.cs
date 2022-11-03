using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    ///hide in inspector
    [HideInInspector] public MovementInMatriz movementInMatriz;

    [SerializeField] public KeyCode up = KeyCode.W;
    [SerializeField] public KeyCode down = KeyCode.S;
    [SerializeField] public KeyCode left = KeyCode.A;
    [SerializeField] public KeyCode right = KeyCode.D;

    // Start is called before the first frame update
    void Start()
    {
        movementInMatriz = GetComponent<MovementInMatriz>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(up))
        {
            movementInMatriz.Move(3);
        }
        if (Input.GetKeyDown(down))
        {
            movementInMatriz.Move(2);
        }
        if (Input.GetKeyDown(left))
        {
            movementInMatriz.Move(0);
        }
        if (Input.GetKeyDown(right))
        {
            movementInMatriz.Move(1);
        }
    }

}
