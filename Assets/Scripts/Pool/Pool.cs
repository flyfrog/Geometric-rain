using System;
using UnityEngine;
using System.Collections.Generic;


public class Pool<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }
    private List<T> poolList;
    



    public Pool(T prefabArg, int countArg, Transform containerArg = null)
    {
        prefab = prefabArg;
        container = containerArg;

        CreatePool(countArg);
    }

    private void CreatePool(int countArg)
    {
        poolList = new List<T>();

        for (int i = 0; i < countArg; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var newObject = UnityEngine.Object.Instantiate(prefab, container);
        newObject.gameObject.SetActive(isActiveByDefault);
        poolList.Add(newObject);
        return newObject;
    }


    public bool HasFreeElement(out T element)
    {
        foreach (var mono in poolList)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
            return element;

        if (autoExpand)
            return CreateObject(true);

        throw new Exception($"There is no free elenebt {typeof(T)}");
    }

 


    public int GetCountPool()
    {
        return poolList.Count;
    }

    public List<T> GetAllPoolElementsList()
    {
        return poolList;
    }


    public List<T> GetAllActivelElementsList()
    {
        List<T> freeElementsPoolList = new List<T>(); 
        foreach (var mono in poolList)
        {
            if (mono.gameObject.activeInHierarchy)
            {       
                freeElementsPoolList.Add(mono);   
            }
        }
        return freeElementsPoolList; 
    }


    public int GetCountFreeElementsPool()
    {
        int freeCount = 0 ; 
        foreach (var mono in poolList)
        {
            if (!mono.gameObject.activeInHierarchy)
            {       
                freeCount++;   
            }
        }
        return freeCount; 
    }
    //получить колличество свободных элементов 
 



}