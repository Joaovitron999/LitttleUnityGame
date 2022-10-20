using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatricialWorld : MonoBehaviour
{
    public GameObject slot;
    public GameObject[][] world;
    public int lines = 8;
    public int columns = 4;
    private bool worldCreated = false;

    private GameObject Player;


    public void GenerateWorld()
    {
        DestroyWorld();
        world = new GameObject[lines][];
        for (int i = 0; i < lines; i++)
        {
            world[i] = new GameObject[columns];
            for (int j = 0; j < columns; j++)
            {
                world[i][j] = Instantiate(slot, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //setting neighbors
                world[i][j].GetComponent<SlotScript>().SetNeighbors(world, i, j);  
            }
        }
        worldCreated = true;

        Player.GetComponent<MovementInMatriz>().slot = world[(int)lines / 2][(int)columns / 2];
        Player.transform.position = world[(int)lines / 2][(int)columns / 2].transform.position;
    }

    public void DestroyWorld()
    {
        if(worldCreated)
        {
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(world[i][j] != null)
                    {
                        Destroy(world[i][j], 1/(0.1f+(float)i+j));
                    }
                }
            }
            worldCreated = false;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        GenerateWorld();
    }
}
