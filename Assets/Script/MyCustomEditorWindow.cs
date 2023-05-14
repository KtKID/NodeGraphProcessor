using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using Sirenix.OdinInspector;


public class MyCustomEditorWindow : OdinMenuEditorWindow
{
    [MenuItem("CustomWindows/MyCustomEditorWindow")]
    public static void OpenWindow()
    {
        GetWindow<MyCustomEditorWindow>().Show();
    }
    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        tree.Selection.SupportsMultiSelect = false;

        tree.Add("Settings", GeneralDrawerConfig.Instance);
        tree.Add("Utilities", new TextureUtilityEditor());
        tree.Add("Entity", new EntityEditor());
        tree.AddAllAssetsAtPath("Odin Settings", "Assets/Plugins/Sirenix", typeof(ScriptableObject), true, true);
        return tree;
    }
    public class TextureUtilityEditor
    {
        [BoxGroup("Tool"), HideLabel, EnumToggleButtons]
        public Tool Tool;

        public List<Texture> Textures;

        [Button(ButtonSizes.Large), HideIf("Tool", Tool.Rotate)]
        public void SomeAction() { }

        [Button(ButtonSizes.Large), ShowIf("Tool", Tool.Rotate)]
        public void SomeOtherAction() { }
    }

    public class XgtEditor
    {
        [BoxGroup("Tool"), HideLabel, EnumToggleButtons]
        public Tool Tool;

        public List<Texture> Textures;

        [Button(ButtonSizes.Large), HideIf("Tool", Tool.Rotate)]
        public void SomeAction() { }

        [Button(ButtonSizes.Large), ShowIf("Tool", Tool.Rotate)]
        public void SomeOtherAction() { }
        [BoxGroup("My Group")]
        [Button(ButtonSizes.Large)]
        private void MyButton()
        {
            Debug.Log("Button Clicked!");
        }
        [BoxGroup("My Group2")]
        [Button(ButtonSizes.Large)]
        private void MyButton2()
        {
            Debug.Log("Button2 Clicked!");
        }
    }

    [ButtonGroup]
    private void A()
    {
    }

    [ButtonGroup]
    private void B()
    {
    }

    [ButtonGroup]
    private void C()
    {
    }

    [ButtonGroup]
    private void D()
    {
    }

    [Button(ButtonSizes.Large)]
    [ButtonGroup("My Button Group")]
    private void E()
    {
    }

    [GUIColor(0, 1, 0)]
    [ButtonGroup("My Button Group")]
    private void F()
    {
    }
}
