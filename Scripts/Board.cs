using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    [SerializeField] Transform board;
    GameManager gm;

    public void CreateBoard(int size)
    {
        gm = GameManager.instance;
        for (int i = 0; i < size * size; i++)
        {
            Cell cell = Instantiate(cellPrefab, board).GetComponent<Cell>();
            cell.pos = new Vector2(i % size, i / size);
            gm.cells[i % size, i / size] = cell;
        }
    }
}
