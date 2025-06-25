using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell MazeCellPrefab;

    [SerializeField]
    private GameObject Maze;

    [SerializeField]
    private int length;

    [SerializeField]
    private int breadth;

    private MazeCell[,] mazeGrid;

    // to watch the maze being generated in real time, convert it to a coroutine , change the return type of Start and GenerateMaze to IEnumerator and add yield statements
    void Start()
    {
        mazeGrid = new MazeCell[length, breadth];

        for (int i = 0; i < length; ++i)
        {
            for (int j = 0; j < breadth; ++j)
            {
                MazeCell cell = Instantiate(MazeCellPrefab, new Vector3(i, 0, j), Quaternion.identity, Maze.transform);
                cell.name = "Cell " + i + " " + j;
                mazeGrid[i, j] = cell;

                // Only the leftmost column should keep their left walls
                if (i > 0)
                    cell.ClearLeftWall();

                // Only the bottom row should keep their back walls
                if (j > 0)
                    cell.ClearBackWall();
            }
        }

        GenerateMaze(null, mazeGrid[0, 0]);
    }


    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);

        // yield return new WaitForSeconds(0.2f);

        MazeCell nextCell;
        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);
            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
            
        } while (nextCell != null);

    }

    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);
        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;

        if (x + 1 < length)
        {
            var CellToRight = mazeGrid[x + 1, z];
            if (CellToRight.IsVisited == false)
            {
                yield return CellToRight;
            }
        }

        if (x - 1 >= 0)
        {
            var CellToLeft = mazeGrid[x - 1, z];
            if (CellToLeft.IsVisited == false)
            {
                yield return CellToLeft;
            }
        }

        if (z + 1 < breadth)
        {
            var CellToFront = mazeGrid[x, z + 1];
            if (CellToFront.IsVisited == false)
            {
                yield return CellToFront;
            }
        }

        if (z - 1 >= 0)
        {
            var CellToBack = mazeGrid[x, z - 1];
            if (CellToBack.IsVisited == false)
            {
                yield return CellToBack;
            }
        }

    }

    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if(previousCell == null)
        {
            return;
        }

        if(previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }

        if(previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }

        if(previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }

        if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
