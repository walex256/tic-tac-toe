using UnityEngine;

public class Board : MonoBehaviour
{
    public enum CellState { Empty, Cross, Circle }

    [Header("Prefabs")]
    [SerializeField] private GameObject m_crossPrefab;
    [SerializeField] private GameObject m_circlePrefab;

    private CellState[,] m_grid = new CellState[3, 3];
    private bool m_crossTurn = true;
    private bool m_gameOver;

    public void TryPlace(int x, int y, Vector3 position)
    {
        if (m_gameOver) return;
        if (m_grid[x, y] != CellState.Empty) return;

        GameObject prefab = m_crossTurn ? m_crossPrefab : m_circlePrefab;
        Instantiate(prefab, position, Quaternion.identity);

        m_grid[x, y] = m_crossTurn ? CellState.Cross : CellState.Circle;

        if (CheckWin(m_grid[x, y]))
        {
            Debug.Log($"{m_grid[x, y]} победили!");
            m_gameOver = true;
            return;
        }

        m_crossTurn = !m_crossTurn;
    }

    private bool CheckWin(CellState state)
    {
        for (int i = 0; i < 3; i++)
        {
            if (m_grid[i, 0] == state && m_grid[i, 1] == state && m_grid[i, 2] == state) return true;
            if (m_grid[0, i] == state && m_grid[1, i] == state && m_grid[2, i] == state) return true;
        }

        if (m_grid[0, 0] == state && m_grid[1, 1] == state && m_grid[2, 2] == state) return true;
        if (m_grid[2, 0] == state && m_grid[1, 1] == state && m_grid[0, 2] == state) return true;

        return false;
    }
}
