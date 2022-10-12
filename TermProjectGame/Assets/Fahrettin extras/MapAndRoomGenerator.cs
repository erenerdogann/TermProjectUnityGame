using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAndRoomGenerator : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject[] Rooms;
    private int ObjectMaxSize = 0;
    private int RoomMaxSize = 0;
    private int[] FinalArrayObjects;
    private int[] FinalArrayRooms;

    private void Start()
    {
        ObjectMaxSize = objects.Length;
        RoomMaxSize = Rooms.Length;
        ObjectMaxSize = objects.Length;
        FinalArrayObjects = Calculator(ObjectMaxSize);
        FinalArrayRooms = Calculator(RoomMaxSize);
        //Also can be useful with the way of using array packtges:
        /*
         * objectsArray = Calculator(ObjectMaxSize);
         * RoomsArray = Calculator(RoomMaxSize);
        */
    }
    //private GameObject[] objectsArray;
    //private GameObject[] RoomsArray;

    private int[] Calculator(int maxSize)
    {
        int[] RandomNumberarray = new int[maxSize];
        for (int i = 0; i < RandomNumberarray.Length; i++)
        {
            do
            {
                //Debug.Log("I draw another number");
                RandomNumberarray[i] = Random.Range(0, objects.Length);
            } while (Controller(RandomNumberarray, RandomNumberarray.Length, i));
            Debug.Log("I found onether number!!");
        }
        return RandomNumberarray;
    }

    private bool Controller(int[] random_Number, int length, int turn)
    {
        for (int controller = 0; controller < length; controller++)
        {
            if (turn != controller)
            {
                if (random_Number[turn] == random_Number[controller])
                {
                    return true;
                }
            }

        }
        return false;
    }

    protected int[] Get_FinalArrayObjects()
    {
        return FinalArrayObjects;
    }

    protected int[] Get_FinalArrayRooms()
    {
        return FinalArrayRooms;
    }

    protected int GetSpesificObject_FinalArrayObjects(int wanted)
    {
        for (int i=0; i < FinalArrayObjects.Length; i++)
            if (i == wanted)
                return FinalArrayObjects[i];
        return -1;
    }

    protected int GetSpesificObject_FinalArrayRooms(int wanted)
    {
        for (int i = 0; i < FinalArrayRooms.Length; i++)
            if (i == wanted)
                return FinalArrayRooms[i];
        return -1;
    }

    //Notes:
    //Instantiate(objects[rand], transform.position, Quaternion.identity);
}
