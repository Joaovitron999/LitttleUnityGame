using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInMatriz : MonoBehaviour
{

    //matricial world
    public MatricialWorld world;
    public GameObject slot;

    //movement
    public float speed = 10f;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        //find game object world with tag "World" and get the script MatricialWorld
        world = GameObject.FindGameObjectWithTag("World").GetComponent<MatricialWorld>();
    }

    


    // Update is called once per frame
    void Update(){
        if(slot)
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
        else
        {
            if(world.worldCreated)
            {
                if(!world.world[(int)world.lines / 2][(int)world.columns / 2].GetComponent<SlotScript>().isOccupied)
                {
                    slot = world.world[(int)world.lines / 2][(int)world.columns / 2];
                    slot.GetComponent<SlotScript>().SetOccupant(gameObject);
                }
                else
                {
                    while (!slot)
                    {
                        int i = Random.Range(0, world.lines);
                        int j = Random.Range(0, world.columns);
                        if (!world.world[i][j].GetComponent<SlotScript>().isOccupied)
                        {
                            slot = world.world[i][j];
                            slot.GetComponent<SlotScript>().SetOccupant(gameObject);
                        }
                    }
                }
                transform.position = slot.transform.position;
            }
        }
    }

    public void Move(int direction){
        if (canMove && slot.GetComponent<SlotScript>().neighbors[direction])
        {
            //Debug.Log("Moving to " + slot.GetComponent<SlotScript>().neighbors[direction].transform.position);
            if (slot.GetComponent<SlotScript>().neighbors[direction].GetComponent<SlotScript>().isOccupied == false)
            {
                slot.GetComponent<SlotScript>().SetOccupant(null);
                slot = slot.GetComponent<SlotScript>().neighbors[direction].gameObject;
                slot.GetComponent<SlotScript>().SetOccupant(gameObject);

                //transform.position = slot.transform.position;
                Debug.Log("Moved to " + slot.transform.position);
                canMove = false;
            }
        }

    }
}
