using UnityEngine.SceneManagement;

namespace Core
{
    public static class LevelUtils
    {
        public static void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}