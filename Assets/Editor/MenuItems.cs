using UnityEditor;
namespace RollBall
{
    public class MenuItems
    {
        [MenuItem("SAS/��� ����")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "SAS");
        }
    }
}
