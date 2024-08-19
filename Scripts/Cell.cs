using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Image image;
    Button button;
    GameManager gm;
    public Vector2 pos;
    [SerializeField] Sprite xSprite;
    [SerializeField] Sprite oSprite;
    [SerializeField] Sprite noneSprite;

    public int lable = 0; // 0: none, 1: x, 2: o
    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }
    void Start()
    {
        gm = GameManager.instance;
        button.onClick.AddListener(ChangeSprite);
    }

    void ChangeSprite()
    {
        if (image.sprite != noneSprite) return;
        image.sprite = gm.xTurn ? xSprite : oSprite;
        lable = gm.xTurn ? 1 : 2;
        gm.xTurn = !gm.xTurn;
        gm.CheckGameOver(pos, lable);
    }


}