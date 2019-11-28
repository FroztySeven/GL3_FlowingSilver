using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawn : MonoBehaviour
{
    [SerializeField] GameObject mine;
    [SerializeField] GameObject MineField;
    public int NumberOfMines;
    Vector3[] SpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        
        Vector3[] SpawnPoints = new Vector3[NumberOfMines];
        for (int i = 0; i < NumberOfMines; i++)
        {
            SpawnPoints[i].x = Random.Range(MineField.transform.position.x -MineField.GetComponent<Collider>().bounds.size.x/2 , MineField.transform.position.x + MineField.GetComponent<Collider>().bounds.size.x / 2);
            SpawnPoints[i].y = MineField.transform.position.y;
            SpawnPoints[i].z = Random.Range(MineField.transform.position.z - MineField.GetComponent<Collider>().bounds.size.z / 2, MineField.transform.position.z + MineField.GetComponent<Collider>().bounds.size.z / 2);
        }
        for (int i = 0; i < NumberOfMines; i++)
        {
            Instantiate(mine, new Vector3 (SpawnPoints[i].x, SpawnPoints[i].y, SpawnPoints[i].z),Quaternion.identity);
        }
    }
   
}
