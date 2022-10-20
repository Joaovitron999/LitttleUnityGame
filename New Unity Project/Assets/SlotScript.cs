using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public GameObject[] neighbors = new GameObject[4];
    public GameObject occupant;
    public bool isOccupied = false;

    public void SetOccupant(GameObject newOccupant)
    {
        occupant = newOccupant;
        if(occupant != null)
        {
            isOccupied = true;
        }
        else
        {
            isOccupied = false;
        }
    }

    //Start is called before the first frame update
    void Start()
    {
        SetOccupant(null);   
    }

    public void SetNeighbors(GameObject[][] world, int i, int j)
    {
        neighbors = new GameObject[4];
        if (i > 0)
        {
            neighbors[0] = world[i - 1][j];
        }
        if (i < world.Length - 1)
        {
            neighbors[1] = world[i + 1][j];
        }
        if (j > 0)
        {
            neighbors[2] = world[i][j - 1];
        }
        if (j < world[i].Length - 1)
        {
            neighbors[3] = world[i][j + 1];
        }
    }

}
