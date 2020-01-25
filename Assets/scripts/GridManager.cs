using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public InputField girdi;
    public GameObject gridholder,gamepanel;
    [SerializeField]
    private int GridSize;
    private float TileSize=100;
    private GameObject[,] gridObjects;
    private bool GridActive = false,sag,sol,üst,alt;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GridActive) { 
        for (int row = 0; row < GridSize; row++)
        {
                for (int col = 0; col < GridSize; col++)
                {
                    if (gridObjects[row, col].tag == "act")
                    {
                       
                        sol = false;
                        sag = false;
                        üst = false;
                        alt = false;
                        if (col < GridSize - 1)
                        {
                            if (gridObjects[row, col + 1].tag == "act")
                            {
                                üst = true;
                            }
                        }
                        if (col > 0)
                        {
                            if (gridObjects[row, col - 1].tag == "act")
                            {
                                alt = true;
                            }
                        }
                        if (row < GridSize - 1)
                        {
                            if (gridObjects[row + 1, col].tag == "act")
                            {
                                sag = true;
                            }
                        }
                        if (row > 0)
                        {
                            if (gridObjects[row - 1, col].tag == "act")
                            {
                                sol = true;

                            }
                        }
                        if (üst && alt)
                        {
                            gridObjects[row, col].tag = "pas";
                            gridObjects[row, col].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row, col + 1].tag = "pas";
                            gridObjects[row, col + 1].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row, col - 1].tag = "pas";
                            gridObjects[row, col - 1].transform.GetChild(0).gameObject.SetActive(false);
                            sol = false;
                            sag = false;
                            üst = false;
                            alt = false;
                        }
                        if (sag && sol)
                        {
                            gridObjects[row, col].tag = "pas";
                            gridObjects[row, col].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row + 1, col].tag = "pas";
                            gridObjects[row + 1, col].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row - 1, col].tag = "pas";
                            gridObjects[row - 1, col].transform.GetChild(0).gameObject.SetActive(false);
                            sol = false;
                            sag = false;
                            üst = false;
                            alt = false;
                        }
                        if (üst && sol)
                        {
                            gridObjects[row, col].tag = "pas";
                            gridObjects[row, col].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row, col + 1].tag = "pas";
                            gridObjects[row, col + 1].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row - 1, col].tag = "pas";
                            gridObjects[row - 1, col].transform.GetChild(0).gameObject.SetActive(false);
                            sol = false;
                            sag = false;
                            üst = false;
                            alt = false;
                        }
                        if (üst && sag)
                        {
                            gridObjects[row, col].tag = "pas";
                            gridObjects[row, col].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row, col + 1].tag = "pas";
                            gridObjects[row, col + 1].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row + 1, col].tag = "pas";
                            gridObjects[row + 1, col].transform.GetChild(0).gameObject.SetActive(false);
                            sol = false;
                            sag = false;
                            üst = false;
                            alt = false;
                        }
                        if (alt && sol)
                        {
                            gridObjects[row, col].tag = "pas";
                            gridObjects[row, col].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row, col - 1].tag = "pas";
                            gridObjects[row, col - 1].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row - 1, col].tag = "pas";
                            gridObjects[row - 1, col].transform.GetChild(0).gameObject.SetActive(false);
                            sol = false;
                            sag = false;
                            üst = false;
                            alt = false;
                        }
                        if (alt && sag)
                        {
                            gridObjects[row, col].tag = "pas";
                            gridObjects[row, col].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row, col - 1].tag = "pas";
                            gridObjects[row, col - 1].transform.GetChild(0).gameObject.SetActive(false);
                            gridObjects[row + 1, col].tag = "pas";
                            gridObjects[row + 1, col].transform.GetChild(0).gameObject.SetActive(false);
                            sol = false;
                            sag = false;
                            üst = false;
                            alt = false;
                        }




                    }
                }
        }
    }
    }
    public void GenerateGrid()
    {
        GameObject RefTile = (GameObject)Instantiate(Resources.Load("XTile"));
        gridholder.transform.localScale = new Vector2(1, 1);
        for (int row = 0; row< GridSize; row++)
        {
            for (int col = 0; col < GridSize; col++)
            {
                float posX = col * TileSize;
                float posY = row * -TileSize;
                GameObject tile = (GameObject)Instantiate(RefTile, transform);
                gridObjects[row, col] = tile.gameObject;
                tile.transform.SetParent(gridholder.transform);
                tile.transform.localPosition = new Vector2(posX, posY);
               

            }
        }
        Destroy(RefTile);
        gridholder.transform.localScale = new Vector2(6, 6);
        gridholder.transform.localScale = new Vector2(gridholder.transform.localScale.x / GridSize, gridholder.transform.localScale.y / GridSize);
        gridholder.transform.localPosition = new Vector2((GridSize - 1) * -50, (GridSize - 1) * 50);
        if (GridSize < 7)
        {

            switch (GridSize)
            {
                case 1: gridholder.transform.localPosition = new Vector2(0, 0); break;
                case 2: gridholder.transform.localPosition = new Vector2(-150, 150); break;
                case 3: gridholder.transform.localPosition = new Vector2(-200, 200); break;
                case 4: gridholder.transform.localPosition = new Vector2(-225, 225); break;
                case 5: gridholder.transform.localPosition = new Vector2(-237, 237); break;
                case 6: gridholder.transform.localPosition = new Vector2(-250, 250); break;

                default:
                    break;
            }
        }
        else if(GridSize<11)
        {
            int holder = GridSize - 6;
            holder = holder * 5;
            gridholder.transform.localPosition = new Vector2(-250 - holder, 250 + holder);

        }
        else if (GridSize<22)
        {
            int holder = GridSize - 6;
            holder = holder * 3;
            gridholder.transform.localPosition = new Vector2(-250 - holder, 250 + holder);
        }
        else
        {
            int holder = GridSize - 6;
            holder = holder * 1;
            gridholder.transform.localPosition = new Vector2(-250 - holder, 250 + holder);
        }



        GridActive = true;
    }
    public void GenGrid() {
        
        GridSize = int.Parse(girdi.text);
        if (GridSize<1)
        {
            GridSize = 1;
        }
        foreach (Transform child in gridholder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        gridObjects = new GameObject[GridSize, GridSize];
        GenerateGrid();

    }
}
