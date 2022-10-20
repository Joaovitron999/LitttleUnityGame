using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInMatriz : MonoBehaviour
{

    //matricial world
    public MatricialWorld world;
    public GameObject slot;

    //movement
    public float speed = 1f;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        world = FindObjectOfType<MatricialWorld>();

    }

    // Update is called once per frame
    void Update(){
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Move(3);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Move(2);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(0);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(1);
            }
        }
        if(slot != null)
        {
            if (transform.position == slot.transform.position)
            {
                canMove = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, slot.transform.position, speed * Time.deltaTime);
            }
        }
    }

    void Move(int direction){
        if (slot.GetComponent<SlotScript>().neighbors[direction] != null)
        {
            //Debug.Log("Moving to " + slot.GetComponent<SlotScript>().neighbors[direction].transform.position);
            if (slot.GetComponent<SlotScript>().neighbors[direction].GetComponent<SlotScript>().isOccupied == false)
            {
                slot = slot.GetComponent<SlotScript>().neighbors[direction].gameObject;

                //transform.position = slot.transform.position;
                Debug.Log("Moved to " + slot.transform.position);
                canMove = false;
            }
        }

    }
}
