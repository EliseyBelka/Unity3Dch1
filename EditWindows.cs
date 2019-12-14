using UnityEngine; 
using UnityEditor;
using Random = UnityEngine.Random; //псевдонима класс - указатель на наследуемый класс
namespace TestWindows
{
    public class EditWindows : EditorWindow
    {
        public GameObject InstantiateGO;                    //~ под поле ГО
        string NameGO;                                      //~ под поле имени ГО
        bool TriggerGroup;                                  //переключатель видимости группы
        bool TriggerRandomColor;                            //переключатель произвольного цвета
        int NumberGO;                                       //количество ГО
        float SizeGO;                                       //размер ГО
        float SpawnArea;                                    //размер зоны спавна
        Color[] ColorsGO = new Color[] { Color.green, Color.white, Color.cyan, Color.magenta };
        [MenuItem("Test/Edit Windows")]                     //создание пункта меню:

        public static void ShowWindow()                     //показать окно
        {
            EditorWindow.GetWindow(typeof(EditWindows));    //вызов окна с использованием Рефлексии 
        }

        void OnGUI()                                        //отрисовка окна
        {
            GUILayout.Label("Основные настройки");          //авто метка(текстовая строка)
            //создание поле для объекта установливаемого пользователем
            InstantiateGO = EditorGUILayout.ObjectField("Вставьте сюда GO", InstantiateGO, typeof(GameObject), true) as GameObject;
            //создает поле в котором можно редактировать текст
            NameGO = EditorGUILayout.TextField("Строка для ввода текста ", NameGO);
            
            //начало групируемого участка
            TriggerGroup = EditorGUILayout.BeginToggleGroup("Настройки ГО", TriggerGroup);
            //тумблер случайного выбора цвета
            TriggerRandomColor = EditorGUILayout.Toggle("Рандомный цвет", TriggerRandomColor);
            //слайдер выбора количества ГО
            NumberGO = EditorGUILayout.IntSlider("Количество игровых объектов", NumberGO, 1, 100);
            //слайдер выбора размера ГО
            SizeGO = EditorGUILayout.Slider("Размер игрового объекта", SizeGO, 10, 50);
            //Слайдер зоны спавна
            SpawnArea = EditorGUILayout.Slider("Размер зоны спавна", SpawnArea, 10, 100);
            //конец групируемого участка
            EditorGUILayout.EndToggleGroup();

            //если нажата кнопка
            if (GUILayout.Button("Создать объекты"))
            {
                //если объект вставлен в поле
                if (InstantiateGO)
                    CreateAlgoritm();
            }
        }
       public void CreateAlgoritm()
        {
            {
                //создание игрового объекта с именем Root
                GameObject Root = new GameObject("Root");

                //НАЧАЛО АЛГОРИТМа РАССТАНОВКИ ОБЪЕКТОВ ПО СЦЕНЕ
                //счетчик объектов
                for (int i = 0; i < NumberGO; i++)
                {
                    Vector3 pos = new Vector3(Random.Range(-SpawnArea, SpawnArea), 0, Random.Range(-SpawnArea, SpawnArea));
                    GameObject temp = Instantiate(InstantiateGO, pos, Quaternion.identity) as GameObject;
                    temp.name = NameGO + "(" + i + ")";
                    temp.transform.parent = Root.transform;
                    if (temp.GetComponent<Renderer>() && TriggerRandomColor)
                    {
                        temp.GetComponent<Renderer>().material.color = ColorsGO[Random.Range(0, ColorsGO.Length - 1)];
                    }
                }
            }
        }
    }
}
