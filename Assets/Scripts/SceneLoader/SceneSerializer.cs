using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public  class SceneSerializer : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(SerializeSceneToString());
        string filePath = "example.txt";
        string content = SerializeSceneToString();
        CreateTextFile(filePath, content);
    }
    public static string SerializeSceneToString()
    {
        Scene scene = SceneManager.GetActiveScene();
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("--- !u!1 &" + scene.GetHashCode());
        sb.AppendLine("Scene:");
        foreach (GameObject go in scene.GetRootGameObjects())
        {
            //Debug.Log(sb);
            SerializeGameObject(go, sb, 1);
        }

        return sb.ToString();
    }

    private static void SerializeGameObject(GameObject go, StringBuilder sb, int level)
    {
        sb.Append(' ', level * 2).AppendLine("- !u!1 &" + go.GetHashCode());
        sb.Append(' ', level * 2).AppendLine("  GameObject:");
        sb.Append(' ', level * 2).AppendLine("    m_ObjectHideFlags: 0");
        sb.Append(' ', level * 2).AppendLine("    m_PrefabParentObject: {fileID: 0}");
        sb.Append(' ', level * 2).AppendLine("    m_CorrespondingSourceObject: {fileID: 0}");
        sb.Append(' ', level * 2).AppendLine("    m_Layer: " + go.layer);
        sb.Append(' ', level * 2).AppendLine("    m_Name: " + go.name);
        sb.Append(' ', level * 2).AppendLine("    m_TagString: " + go.tag);
        sb.Append(' ', level * 2).AppendLine("    m_StaticEditorFlags: 0");
        sb.Append(' ', level * 2).AppendLine("    m_IsActive: " + go.activeSelf.ToString().ToLower());
        sb.Append(' ', level * 2).AppendLine("    m_Component:");
        foreach (Component c in go.GetComponents<Component>())
        {
            if (c == null)
            {
                Debug.LogWarning("Missing Component in GameObject " + go.name);
                continue;
            }

            Type type = c.GetType();
            string guid = Guid.NewGuid().ToString().Replace("-", "");
            sb.Append(' ', (level + 1) * 2).AppendLine("- component: {fileID: " + guid + "}");
            sb.Append(' ', (level + 2) * 2).AppendLine("&" + guid + " " + type.AssemblyQualifiedName + ":");
            sb.Append(' ', (level + 3) * 2).AppendLine("m_ObjectHideFlags: 0");
            SerializeFields(c, sb, level + 3);
        }

        if (go.transform.childCount > 0)
        {
            sb.Append(' ', level * 2).AppendLine("  m_Children:");
            foreach (Transform child in go.transform)
            {
                SerializeGameObject(child.gameObject, sb, level + 2);
            }
        }
    }

    private static void SerializeFields(object obj, StringBuilder sb, int level)
    {
        Type type = obj.GetType();
        BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        foreach (FieldInfo fieldInfo in type.GetFields(bindingFlags))
        {
            if (fieldInfo.IsStatic)
            {
                continue;
            }

            string fieldName = fieldInfo.Name;
            Type fieldType = fieldInfo.FieldType;
            object fieldValue = fieldInfo.GetValue(obj);
            sb.Append(' ', level * 2).Append(fieldName).Append(": ");

            if (fieldType == typeof(string))
            {
                sb.Append('\"').Append(fieldValue).AppendLine("\"");
            }
            else if (fieldType.IsValueType)
            {
                sb.AppendLine(fieldValue.ToString().ToLower());
            }
            else if (typeof(UnityEngine.Object).IsAssignableFrom(fieldType))
            {
                sb.AppendLine("{fileID: 0}");
            }
            else if (fieldType.IsArray)
            {
                sb.AppendLine();
                sb.Append(' ', (level + 1) * 2).AppendLine("Array:");

                if (fieldType.GetElementType().IsValueType || fieldType.GetElementType() == typeof(string))
                {
                    sb.Append(' ', (level + 2) * 2).Append("- ");

                    IList list = (IList)fieldValue;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i > 0)
                        {
                            sb.AppendLine();
                            sb.Append(' ', (level + 2) * 2).Append("- ");
                        }

                        sb.Append(list[i].ToString());
                    }
                }
                else
                {
                    sb.Append(' ', (level + 2) * 2).AppendLine("- Array: ");
                    IList list = (IList)fieldValue;
                    for (int i = 0; i < list.Count; i++)
                    {
                        SerializeFields(list[i], sb, level + 2);
                    }
                }
            }
            else
            {
                sb.AppendLine("{ }");
            }
        }
    }
    public static void CreateTextFile(string filePath, string content)
    {
        // Create the file if it doesn't exist
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        // Write the content to the file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(content);
        }
    }
}



