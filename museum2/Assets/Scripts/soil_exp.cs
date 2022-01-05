using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 토양관 - 산성비 체험관 */

public class soil_exp : MonoBehaviour
{
    public GameObject dome;
    public GameObject Sound, afterSound;
    public GameObject Button;

    List<Color> colors;
    List<Color> riceColors;

    List<int> treeColorIdx;
    List<int> riceColorIdx;

    GameObject[] trees;
    GameObject[] rices;
    GameObject[] smogs;

    public Material tree1, tree2, tree3;
    public Material rice1, rice2, rice3, rice4, rice5;
    List<Material> treeMats;
    List<Material> riceMats;


    public GameObject smog1, smog2, light1;

    public GameObject player;

    bool flag;

    void Start()
    {   
        flag = false;
        colors = new List<Color>();
        riceColors = new List<Color>();
        treeColorIdx = new List<int>();
        riceColorIdx = new List<int>();
        treeMats = new List<Material>();
        riceMats = new List<Material>();

        treeMats.Add(tree1); treeMats.Add(tree2); treeMats.Add(tree3);
        riceMats.Add(rice1); riceMats.Add(rice2); riceMats.Add(rice3); riceMats.Add(rice4); riceMats.Add(rice5);

        trees = GameObject.FindGameObjectsWithTag("soil_exp_tree");
        rices = GameObject.FindGameObjectsWithTag("soil_exp1_rice");
        smogs = GameObject.FindGameObjectsWithTag("soil_exp_smog");

        for (int i = 0; i < trees.Length; i++) {
            int r = Random.Range(0, 3);
            treeColorIdx.Add(r);
        }

        for (int i = 0; i < rices.Length; i++) {
            int r = Random.Range(0, 4);
            riceColorIdx.Add(r);
        }
        
        colors.Add(new Color(76/255f, 135/255f, 88/255f));
        colors.Add(new Color(55/255f, 157/255f, 36/255f));
        colors.Add(new Color(131/255f, 188/255f, 67/255f));

        riceColors.Add(new Color(196/255f, 222/255f, 162/255f));
        riceColors.Add(new Color(183/255f, 227/255f, 125/255f));
        riceColors.Add(new Color(162/255f, 237/255f, 145/255f));
        riceColors.Add(new Color(186/255f, 217/255f, 124/255f));

        // Invoke("ChangeEnv", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag) {
            dome.GetComponent<Renderer>().material.color = Color.Lerp(dome.GetComponent<Renderer>().material.color, new Color(103/255f , 187/255f, 241/255f), 0.05f);

            for (int i = 0; i < trees.Length; i++) {
                trees[i].GetComponent<Renderer>().materials[0].color = Color.Lerp(trees[i].GetComponent<Renderer>().materials[0].color, colors[treeColorIdx[i]], 0.05f);
            }

            for (int i = 0; i < rices.Length; i++) {
                foreach(Transform child in rices[i].transform)
                {
                    child.GetComponent<Renderer>().material.color = Color.Lerp(child.GetComponent<Renderer>().material.color, riceColors[riceColorIdx[i]], 0.05f);
                }
            }
        }
    }
    
    public void ChangeEnv() 
    {
        flag = true;

        Sound.SetActive(false);
        afterSound.SetActive(true);
        Button.GetComponent<Renderer>().material.color = new Color(67/255f, 188/255f, 93/255f);
        
        foreach (GameObject s in smogs) {
            s.SetActive(false);
        }

        smog1.SetActive(true);
        smog2.SetActive(true);
        light1.SetActive(true);
    }

    public void exit() {
        flag = false;
        smog1.SetActive(false);
        smog2.SetActive(false);
        light1.SetActive(false);

        dome.GetComponent<Renderer>().material.color = new Color(101/255f, 94/255f, 81/255f);
        Sound.SetActive(true);
        afterSound.SetActive(false);

        Button.GetComponent<Renderer>().material.color = new Color(204/255f, 115/255f, 100/255f);

        foreach (GameObject s in smogs) {
            s.SetActive(true);
        }

        for (int i = 0; i < trees.Length; i++) {
            int r = Random.Range(0, 3);
            trees[i].GetComponent<Renderer>().materials[0] = treeMats[r];
        }

        for (int i = 0; i < rices.Length; i++) {
            foreach(Transform child in rices[i].transform)
            {
                int r = Random.Range(0, 5);
                child.GetComponent<Renderer>().material.color = Color.Lerp(child.GetComponent<Renderer>().material.color, riceColors[riceColorIdx[i]], 0.05f);
            }
        }
    }
}
