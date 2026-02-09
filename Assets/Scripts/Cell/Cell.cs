using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private Board m_board;   

    public void OnClicked()
    {
        Debug.Log($"Cell clicked {x},{y}");
        m_board.TryPlace(x,y, transform.position);
    }
}
