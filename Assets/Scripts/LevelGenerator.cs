using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{

    public GameObject wall;
    public GameObject floor;
    public GameObject topFloor;
    public GameObject enemy;

    public GameObject winCollider;

    private float wallHeight;

    private float currentWallHeight;

    // private float wallRadius;
    private int floors;
    private float floorHeight;

    private float scale;
    private float scale2;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        GameInfo gameInfo = GameObject.FindObjectOfType<GameInfo>();
        
        floors = gameInfo.currentLevel;
        // floors = 1;
        
        wallHeight = 3f;
        floorHeight = 0.1f;
        scale = 2f;
        scale2 = 2f;
        currentWallHeight = 0;

        // level by level
        for (int i = 1; i < (floors + 1); i++) {
            if (i == 1) {
                // gen. 1st wall
                currentWallHeight += wallHeight * scale;
                GameObject myWall = Instantiate(wall, new Vector3(0, currentWallHeight / 2, 0), Quaternion.identity);

                // gen. 13 enemies
                List<int> spots = new List<int>();
                NavMeshTriangulation Triangulation = NavMesh.CalculateTriangulation();

                // limit spots
                for (int j = 0; j < Triangulation.vertices.Length; j++) {
                    if (Vector3.Distance(Triangulation.vertices[j], new Vector3(0, 0, 0)) > 4) {
                        spots.Add(j);
                    }
                }
                // spawn enemies
                for (int j = 0; j < 13; j++) {
                    // pick spot
                    int currentRandom= Random.Range(0, spots.Count);

                    // spawn
                    Instantiate(enemy, Triangulation.vertices[spots[currentRandom]], Quaternion.identity);

                    // remove spawned spot
                    spots.Remove(currentRandom);
                }


            } else {
                // wallRadius += 4;
                scale += 0.1f;
                scale2 *= 1.4f;
                currentWallHeight += wallHeight * scale;

                // gen. wall
                GameObject myWall = Instantiate(wall, new Vector3(0, currentWallHeight - (wallHeight * scale / 2), 0), Quaternion.identity);
                myWall.transform.localScale = new Vector3(scale2, scale, scale2);

                currentWallHeight -= wallHeight * scale;
                scale -= 0.1f;
                scale2 /= 1.4f;

                // gen. floor and bake nav mesh surface
                GameObject myFloor = Instantiate(floor, new Vector3(0, currentWallHeight + (floorHeight / 2), 0), Quaternion.identity);
                myFloor.transform.localScale = new Vector3(scale2, 1, scale2);
                myFloor.gameObject.GetComponent<NavMeshSurface>().BuildNavMesh();

                // // gen. enemies
                // NavMeshTriangulation Triangulation = NavMesh.CalculateTriangulation();

                // for (int j = 0; j < Triangulation.vertices.Length; j++) {
                //     if (Triangulation.vertices[j].y > myFloor.transform.position.y - 1f &&
                //         Triangulation.vertices[j].y < myFloor.transform.position.y + 1f) {
                //         // GameObject myEnemy;
                //         if (Random.Range(0, 10) == 0) {
                //             Instantiate(enemy, Triangulation.vertices[j], Quaternion.identity);
                //         }
                //     }
                // }

                // gen. + enemies
                List<int> spots = new List<int>();
                NavMeshTriangulation Triangulation = NavMesh.CalculateTriangulation();

                // limit spots
                for (int j = 0; j < Triangulation.vertices.Length; j++) {
                    if (Triangulation.vertices[j].y > myFloor.transform.position.y - 1f &&
                        Triangulation.vertices[j].y < myFloor.transform.position.y + 1f) {
                        spots.Add(j);
                    }
                }

                // spawn enemies
                for (int j = 0; j < 13 + ((i - 1) * 5); j++) {
                    // pick spot
                    int currentRandom= Random.Range(0, spots.Count);

                    // spawn
                    Instantiate(enemy, Triangulation.vertices[spots[currentRandom]], Quaternion.identity);

                    // remove spawned spot
                    spots.Remove(currentRandom);
                }

                scale += 0.1f;
                scale2 *= 1.4f;
                currentWallHeight += wallHeight * scale;
            }
            // generate top floor and win collider
            if (i == floors) {
                scale2 /= 2f;

                GameObject myTopFloor = Instantiate(topFloor, new Vector3(0, currentWallHeight + (floorHeight / 2), 0), Quaternion.identity);
                myTopFloor.transform.localScale = new Vector3(scale2, 1, scale2);

                scale2 *= 2f;
                scale2 += .2f;
                currentWallHeight += wallHeight * scale;

                // gen. wall
                GameObject myWall = Instantiate(winCollider, new Vector3(0, currentWallHeight - (wallHeight * scale / 2), 0), Quaternion.identity);
                myWall.transform.localScale = new Vector3(scale2, scale, scale2);
            }
        }

        Destroy(gameObject);
        // // level by level
        // for (int i = 1; i < (floors + 1); i++) {
        //     if (i == 1) {
        //         // gen. 1st wall
        //         currentWallHeight += wallHeight * scale;
        //         GameObject myWall = Instantiate(wall, new Vector3(0, currentWallHeight / 2, 0), Quaternion.identity);
        //     } else {
        //         wallRadius += 4;
        //         scale += 0.8f;
        //         currentWallHeight += wallHeight * scale;

        //         // gen. wall
        //         GameObject myWall = Instantiate(wall, new Vector3(0, currentWallHeight - (wallHeight * scale / 2), 0), Quaternion.identity);
        //         myWall.transform.localScale = new Vector3(scale, scale, scale);

        //         currentWallHeight -= wallHeight * scale;
        //         scale -= 0.8f;

        //         // gen. floor and bake nav mesh surface
        //         GameObject myFloor = Instantiate(floor, new Vector3(0, currentWallHeight + (floorHeight / 2), 0), Quaternion.identity);
        //         myFloor.transform.localScale = new Vector3(scale, 1, scale);
        //         myFloor.gameObject.GetComponent<NavMeshSurface>().BuildNavMesh();

        //         // gen. enemies
        //         NavMeshTriangulation Triangulation = NavMesh.CalculateTriangulation();

        //         for (int j = 0; j < Triangulation.vertices.Length; j++) {
        //             // gen. enemy if it is inside pit
        //             if (Triangulation.vertices[j].y > myFloor.transform.position.y - 1f &&
        //                 Triangulation.vertices[j].y < myFloor.transform.position.y + 1f &&
        //                 Vector3.Distance(Triangulation.vertices[j], new Vector3(0, currentWallHeight + (floorHeight / 2), 0)) < wallRadius
        //             ) {
        //                 // GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //                 if (Random.Range(0, 5) == 1)
        //                     Instantiate(enemy, Triangulation.vertices[j], Quaternion.identity);
        //             }
        //         }

        //         scale += 0.8f;
        //         currentWallHeight += wallHeight * scale;
        //     }
        // }
    }
}
