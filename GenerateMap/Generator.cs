using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;


namespace GenerateMap
{
    public class Generator : MonoBehaviour
    {
        void Start()
        {
            tmpSize = ParameterManager.instance.tmpSize;
            forestValue = ParameterManager.instance.Forest_Value;
            forestSize = ParameterManager.instance.Size_of_forest;
            buildingValue = ParameterManager.instance.BuildingValue;
            doSim();
        }

        public void doSim()
        {
            width = tmpSize.x;
            height = tmpSize.y;
            mapContent = new int[height, width];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    topMap.SetTile(new Vector3Int
                        (-x + width / 2, -y + height / 2, 0), waterTile);
                }
            }
            //CreateHorizon();
            GenerateBuilding();
            GenerateTree();
            GenerateRock();
            GenerateBush();
            GenerateLoot();
        }

        void CreateHorizon()
        {
            GameObject locTree;
            for (int x = 0; x < horizontLine; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    waterTileMap.SetTile(new Vector3Int
                        (-x + width / 2, -y + height / 2, 0), horizontTile);
                }
            }

            for (int x = width; x > width - horizontLine; x--)
            {
                for (int y = 0; y < height; y++)
                {
                    waterTileMap.SetTile(new Vector3Int
                        (-x + width / 2, -y + height / 2, 0), horizontTile);
                }
            }

            for (int y = 0; y < horizontLine; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    waterTileMap.SetTile(new Vector3Int
                        (-x + width / 2, -y + height / 2, 0), horizontTile);
                }
            }

            for (int y = height; y > height - horizontLine; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    waterTileMap.SetTile(new Vector3Int
                        (-x + width / 2, -y + height / 2, 0), horizontTile);
                }
            }
        }

        public void GenerateBush()
        {
            SpriteRenderer layer = null;
            GameObject locBush = null;
            bool canGenerate = false;
            bool parent = false;
            bushList = new List<GameObject>();
            for (int i = 0; i < bushValue; i++)
            {
                canGenerate = false;

                while (canGenerate != true)
                {
                    int xPar = Random.Range(0, height);
                    int yPar = Random.Range(0, width);

                    canGenerate = FindContent(xPar, yPar, 10);

                    if (canGenerate == true)
                    {
                        locBush = Instantiate(bush);
                        locBush.transform.position = new Vector3
                            (width / 2 - xPar, height / 2 - yPar);
                        layer = locBush.GetComponentInChildren<SpriteRenderer>();
                        layer.sortingOrder = height / 2 - (int) locBush.transform.position.y;
                        bushList.Add(locBush);
                        mapContent[xPar, yPar] = 2;
                        int sizeOfrockPlace = Random.Range(1, 10);
                        for (int j = 0; j < sizeOfrockPlace; j++)
                        {
                            float size = Random.Range(2f, 3.5f);
                            int x = Random.Range(xPar - 1, xPar + 1);
                            int y = Random.Range(yPar - 1, yPar + 1);
                            locBush = Instantiate(bush);
                            locBush.transform.position =
                                new Vector3(width / 2 - x, height / 2 - y);
                            layer = locBush.GetComponentInChildren<SpriteRenderer>();
                            layer.sortingOrder = height / 2 -
                                                 (int) locBush.transform.position.y;
                            bushList.Add(locBush);
                            mapContent[x, y] = 3;
                        }
                    }
                }
            }
        }

        public void GenerateLoot()
        {
            LootList = new List<GameObject>();
            bool generated;
            bool canGenerate;
            int posX, posY;
            for (int i = 0; i < LootList.Count; i++)
            {
                for (int j = 0; j < lootCount[i]; j++)
                {
                    canGenerate = true;
                    generated = false;
                    while (generated != true)
                    {
                        posX = Random.Range(0, width);
                        posY = Random.Range(0, height);
                        canGenerate = FindContent(posX, posY, 3);
                        if (canGenerate == false)
                        {
                            continue;
                        }
                        else
                        {
                            Debug.Log("Loot generated");
                            GameObject loot = Instantiate(LootList[i]);
                            loot.transform.position = new Vector3
                                (width / 2 - posX, height / 2 - posY, 0);
                            loot.GetComponent<SpriteRenderer>().sortingOrder =
                                height / 2 - (int) loot.transform.position.y;
                            generated = true;
                            //mapContent[posX, posY] = 5;
                        }
                    }

                }
            }
        }

        public bool FindContent(int x, int y, int distanceBetweenHouse)
        {
            bool cheker = true;
            for (int i = x - distanceBetweenHouse; i < x + distanceBetweenHouse; i++)
            {
                for (int j = y - distanceBetweenHouse; j < y + distanceBetweenHouse; j++)
                {
                    if (i >= width || j >= height || i <= 0 || j <= 0)
                    {
                        return false;
                    }
                    else
                    {
                        if (mapContent[i, j] != 0)
                        {
                            cheker = false;
                            break;
                        }
                    }
                }

                if (cheker == false)
                {
                    break;
                }
            }

            return cheker;
        }

        public void GenerateBuilding()
        {
            GameObject house = null;
            bool generated = false;
            bool canGenerate = false;
            SpriteRenderer render;
            houseList = new List<GameObject>();
            for (int i = 0; i < buildingValue; i++)
            {
                generated = false;
                while (!generated)
                {
                    int chance = Random.Range(0, 100);
                    int coordX = Random.Range(0 + horizontLine + _horizontHelpLine,
                        width - horizontLine - _horizontHelpLine);
                    int coordY = Random.Range(0 + horizontLine + _horizontHelpLine,
                        height - horizontLine - _horizontHelpLine);

                    if (chance % 2 == 0)
                    {
                        canGenerate = FindContent(coordX, coordY, 15);
                    }
                    else
                    {
                        canGenerate = FindContent(coordX, coordY, 30);
                    }

                    if (canGenerate == true)
                    {
                        if (chance % 2 == 0)
                        {
                            house = Instantiate(this.house);
                        }
                        else
                        {
                            house = Instantiate(bigHouse);
                        }
                        render = house.GetComponent<SpriteRenderer>();
                        house.transform.position = new Vector3
                            (-coordX + width / 2, -coordY + height / 2, 0);
                        render.sortingOrder = height / 2 - (int) house.transform.position.y + 5;
                        houseList.Add(house);
                        mapContent[coordX, coordY] = 1;
                        generated = true;
                        canGenerate = false;
                    }
                    else
                    {
                        canGenerate = false;
                        continue;
                    }
                }
            }
        }

        public void GenerateTree()
        {
            float size;
            SpriteRenderer layer = null;
            GameObject tree = null;
            bool canGenerate = false;
            bool parent = false;
            treeList = new List<GameObject>();
            for (int i = 0; i < forestValue; i++)
            {
                canGenerate = false;
                while (canGenerate != true)
                {
                    int xPar = Random.Range(0, height);
                    int yPar = Random.Range(0, width);
                    canGenerate = FindContent(xPar, yPar, 15);
                    if (canGenerate == true)
                    {
                        mapContent[xPar, yPar] = 4;
                        for (int j = 0; j < forestSize; j++)
                        {
                            int x = Random.Range(xPar - 5, xPar + 5);
                            int y = Random.Range(yPar - 5, yPar + 5);
                            tree = Instantiate(this.tree);
                            size = Random.Range(2.5f, 3);
                            tree.transform.localScale = new Vector3(size, size, 1);
                            tree.transform.position = new Vector3(width / 2 - x, height / 2 - y);
                            layer = tree.GetComponentInChildren<SpriteRenderer>();
                            layer.sortingOrder = height / 2 - (int) tree.transform.position.y;
                            treeList.Add(tree);
                            mapContent[x, y] = 4;
                        }
                    }
                }
            }
        }

        public void GenerateRock()
        {
            SpriteRenderer layer = null;
            GameObject rock = null;
            bool canGenerate = false;
            bool parent = false;
            rockList = new List<GameObject>();
            for (int i = 0; i < rockValue; i++)
            {
                canGenerate = false;
                while (canGenerate != true)
                {
                    int xPar = Random.Range(0, height);
                    int yPar = Random.Range(0, width);
                    canGenerate = FindContent(xPar, yPar, 10);
                    if (canGenerate == true)
                    {
                        rock = Instantiate(this.rock);
                        rock.transform.position = new Vector3(width / 2 - xPar, height / 2 - yPar);
                        layer = rock.GetComponentInChildren<SpriteRenderer>();
                        layer.sortingOrder = height / 2 - (int) rock.transform.position.y;
                        rockList.Add(rock);
                        mapContent[xPar, yPar] = 2;

                        int sizeOfRockPlace = Random.Range(1, 4);
                        for (int j = 0; j < sizeOfRockPlace; j++)
                        {
                            float size = Random.Range(0.5f, 2);
                            int x = Random.Range(xPar - 1, xPar + 1);
                            int y = Random.Range(yPar - 1, yPar + 1);
                            rock = Instantiate(this.rock);
                            rock.transform.localScale = new Vector3(size, size, 0);
                            rock.transform.position = new Vector3(width / 2 - x, height / 2 - y);
                            layer = rock.GetComponentInChildren<SpriteRenderer>();
                            layer.sortingOrder = height / 2 - (int) rock.transform.position.y;
                            rockList.Add(rock);
                            mapContent[x, y] = 3;
                        }
                    }
                }
            }
        }


        public void clearMap(bool complete)
        {
            topMap.ClearAllTiles();
            if (complete)
            {
                _terrainMap = null;

                for (int i = 0; i < buildingValue; i++)
                {
                    Destroy(houseList[i]);
                }

                for (int i = 0; i < forestValue; i++)
                {
                    Destroy(treeList[i]);
                }

                for (int i = 0; i < rockValue; i++)
                {
                    Destroy(rockList[i]);
                }

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        mapContent[i, j] = 0;
                    }
                }

                for (int i = 0; i < _horizontList.Count; i++)
                {
                    Destroy(_horizontList[i]);
                }
            }
        }

        //data members
        public int width;
        public int height;

        //2 - Rock
        //4 - Tree
        //1 - Building
        //3 - bush
        public int[,] mapContent;

        //public GameObject Player;
        private const int _horizontHelpLine = 5;
        public GameObject house;
        public GameObject bigHouse;
        public GameObject tree;
        private List<GameObject> _horizontList;
        [Range(3, 10)] public int forestValue;
        [Range(5, 40)] public int forestSize;
        public List<GameObject> houseList;
        public List<GameObject> treeList;
        private int _count = 0;
        private int[,] _terrainMap;
        public Vector3Int tmpSize;
        public Tilemap topMap;
        public Tile waterTile;
        public Tile winterTile;
        public Tile landTile;
        [Range(1, 40)] public int buildingValue;
        public GameObject rock;
        public List<GameObject> rockList;
        [Range(5, 40)] public int rockValue;
        [Range(5, 40)] private List<GameObject> _mapLootList;
        public int horizontLine;
        public Tilemap waterTileMap;
        public Tile horizontTile;
        public List<GameObject> bushList;
        public List<GameObject> LootList;
        public List<int> lootCount;
        public GameObject bush;
        public int bushValue;
        public Tile autumnTile;
    }
}// end of namespace GenerateMap
