using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAndRoomGenerator : MapGlobalVeriables
{
    public GameObject[] objects;
    public GameObject[] Rooms;

    private GameObject[] Objacts_arr;
    private GameObject[] Room_arr;
    
    private int ObjectMaxSize = 0;
    private int RoomMaxSize = 0;

    private int[] FinalArrayObjects;
    private int[] FinalArrayRooms =null;


    private GameObject[] Adaptor(int[] AdaptedNumArr, GameObject[] ToAdopt)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            int j = AdaptedNumArr[i];
            ToAdopt[i] = objects[j];
        }
        return ToAdopt;
    }

    
    private void Place(GameObject[] wanted, int MaxSize, string WhatItIs)
    {
        for(int i =0; i < MaxSize; i++)
        {
            string FullName = WhatItIs + " (" + i + ")";
            Instantiate(wanted[i], GameObject.Find(FullName).transform.position, Quaternion.identity);
        }
    }

    private void Start()
    {

        ObjectMaxSize = objects.Length;
        RoomMaxSize = Rooms.Length;

        Objacts_arr = new GameObject[ObjectMaxSize];
        Room_arr = new GameObject[RoomMaxSize];

        FinalArrayObjects = Calculator(maxSize: ObjectMaxSize);
        //FinalArrayRooms = Calculator(maxSize: RoomMaxSize);

        Objacts_arr = Adaptor(AdaptedNumArr: FinalArrayObjects, ToAdopt: Objacts_arr);

        //Room_arr = Adaptor(AdaptedNumArr: FinalArrayRooms, ToAdopt: Room_arr);

        Place(wanted: Objacts_arr, MaxSize: ObjectMaxSize, WhatItIs: "Cube");

    }

    private int[] Calculator(int maxSize)
    {
        int[] RandomNumberarray = new int[maxSize];
        for (int i = 0; i < RandomNumberarray.Length; i++)
        {
            do
            {
                RandomNumberarray[i] = Random.Range(0, objects.Length);
            } while (Controller(RandomNumberarray, RandomNumberarray.Length, i));
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

    protected GameObject GetSpesificObject_FinalArrayObjects_AsObject(int wanted)
    {

        if (Objacts_arr[wanted] == null)
            return null;
        return Objacts_arr[wanted];
    }

    protected GameObject GetSpesificObject_FinalArrayRooms_AsObject(int wanted)
    {
        for (int i = 0; i < FinalArrayRooms.Length; i++)
        {
            if (i == wanted)
            {
                return Rooms[i];
            }
        }    
        return null;
    }

    //additions:
    //bullshit but can be usefull:

    /*
     * 
     * private void Print()
    {
        for (int i= 0; i < objects.Length; i++)
        {
            Debug.Log(Objacts_arr[i]);
        }
    }
     * 
     * private void Tester(int[] wanted)
    {
        Debug.Log("The numbers are:");
        for (int i = 0; i < wanted.Length; i++)
        {
            Debug.Log(wanted[i]);
        }
    }
    protected int[] GetAll_FinalArrayObjects_AsInt()
    {
        return FinalArrayObjects;
    }

    protected int[] GetAll_FinalArrayRooms_AsInt()
    {
        return FinalArrayRooms;
    }

    protected int GetSpesificObject_FinalArrayObjects_AsInt(int wanted)
    {
        for (int i=0; i < FinalArrayObjects.Length; i++)
            if (i == wanted)
                return FinalArrayObjects[i];
        return -1;
    }

    protected int GetSpesificObject_FinalArrayRooms_AsInt(int wanted)
    {
        for (int i = 0; i < FinalArrayRooms.Length; i++)
            if (i == wanted)
                return FinalArrayRooms[i];
        return -1;
    }

    public int Retturrnnnnn()
    {
        return 1;
    }

    
         * //horizontal search:
         for (int i = 0; i < objects.Length; i++)
        {
            Debug.Log("I am in first for for value of " + i);
            //Working with spesific value:
            for (int value_in_array = 0; value_in_array < AdaptedNumArr.Length; value_in_array++)
            {
                Debug.Log("I am in First for for value of '" + i + "' and I am trying to find that value inside of array, and I am currently '" + value_in_array+"'");
                //Finding were should sit our spesific value:
                if (AdaptedNumArr[i] == AdaptedNumArr[value_in_array])
                {
                    Debug.Log("I am adding the value of '" + value_in_array + "' and");
                    ToAdopt[0, i] = objects[value_in_array];
                    break;
                }
            }
        }
         */


    //Notes:
    //Instantiate(objects[rand], transform.position, Quaternion.identity);
}
