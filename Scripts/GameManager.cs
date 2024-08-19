using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public bool xTurn;
    public int boardSize;
    [SerializeField] GameObject boardObj;
    [SerializeField] GridLayoutGroup gridLayoutGroup;

    public Cell[,] cells;
    public GameState gs;

    private void Reset()
    {
        boardObj = GameObject.FindGameObjectWithTag("Board");
        gridLayoutGroup = GameObject.FindGameObjectWithTag("BoardCanvas").GetComponent<GridLayoutGroup>();
    }
    void Start()
    {
        if (boardObj == null || gridLayoutGroup == null)
            Reset();

        xTurn = false;
        boardSize = 15;
        gridLayoutGroup.constraintCount = boardSize;
        gs = GameState.Start;
        cells = new Cell[boardSize, boardSize];
        boardObj.GetComponent<Board>().CreateBoard(boardSize);

    }

    private void Update()
    {
        switch (gs)
        {
            case GameState.Start:
                break;
            case GameState.OWin:

                break;
            case GameState.XWin:

                break;
        }
    }

    bool PosInBoard(Vector2 pos)
    {
        if (pos.x < 0 || pos.x >= boardSize) return false;
        else if (pos.y < 0 || pos.y >= boardSize) return false;
        else return true;
    }

    void CheckDirection(Vector2 dir, Vector2 pos, int lable)
    {
        int i = 1;
        Vector2 tmpPos = pos;
        while (PosInBoard(tmpPos + dir)
        && cells[(int)(tmpPos.x + dir.x), (int)(tmpPos.y + dir.y)].lable == lable)
        {

            i++;
            tmpPos += dir;
        }
        tmpPos = pos;
        while (PosInBoard(tmpPos - dir)
        && cells[(int)(tmpPos.x - dir.x), (int)(tmpPos.y - dir.y)].lable == lable)
        {
            i++;
            tmpPos -= dir;

        }
        if (i >= 5)
        {
            if (lable == 1)
            {
                gs = GameState.XWin;
                Debug.Log("X win");
            }
            if (lable == 2)
            {
                Debug.Log("O win");
                gs = GameState.OWin;
            }
        }
    }

    public void CheckGameOver(Vector2 position, int lable)
    {
        CheckDirection(Vector2.right, position, lable);
        CheckDirection(Vector2.up, position, lable);
        CheckDirection(new Vector2(1, 1), position, lable);
        CheckDirection(new Vector2(-1, 1), position, lable);
    }
}
