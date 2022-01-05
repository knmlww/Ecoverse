using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_trash : MonoBehaviour
{
    public GameObject trashPrefab;
    private int count;

    List<GameObject> trashlist;

    void Start()
    {
        
        // InvokeRepeating("GenerateTrash", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateTrash() {
        trashlist = new List<GameObject>();
        count = 0;
        InvokeRepeating("gen", 0.5f, 0.5f);
    }

    public void gen() {
        if (count == 30) return;
        GameObject temp = Instantiate(trashPrefab);
        Vector3 pos = gameObject.transform.position;
        pos.y += 3f;
        temp.transform.position = pos;
        trashlist.Add(temp);
        count++;
    }

    public void deleteTrash() {
        for (int i = 0; i < trashlist.Count; i++) {
            Destroy(trashlist[i]);
        }
    }
}
