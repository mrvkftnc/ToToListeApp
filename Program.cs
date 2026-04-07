
using System.ComponentModel.Design;

namespace TodoListApp
{
    internal class Program
    {
        static string filePath = "tasks.txt";
        static void Main(string[] args)
        {

            List<string> tasks = LoadTasks();

            Console.WriteLine("\n--- Todo List ---");
            Console.WriteLine(" Görev eklemek için 1'e basınız:");
            Console.WriteLine("Görevleri listelemek için 2'ye basınız:");
            Console.WriteLine("Görev silmek için 3'e basınız:");
            Console.WriteLine("Çıkış yapmak için 4'e basınız:");
            while (true)
            {
                Console.WriteLine("Lütfen seçim yapınız:");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.WriteLine("Yeni görev ekleyiniz");
                    string gorev = Console.ReadLine();
                    tasks.Add(gorev);
                    SaveTasks(tasks);
                    Console.WriteLine("Yeni göreviniz başarıyla eklendi");
                }
                else if (secim == "2")
                {
                    Console.WriteLine("Yeni görevler Listeleniyor...");
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("Henüz Görev yok");

                    }
                    else
                    {
                        foreach (string task in tasks)
                        {
                            Console.WriteLine(task);
                        }
                    }
                }
                else if (secim == "3")
                {
                    Console.WriteLine("Silmek istediğiniz görevi seçiniz");
                    string Sgorev = Console.ReadLine();

                    Console.WriteLine("Göreviniz siliniyor...");

                    if (tasks.Remove(Sgorev))
                    {
                        SaveTasks(tasks);
                        Console.WriteLine("Görev başarıyla silindi");
                    }
                    else
                    {
                        Console.WriteLine("Görev Bulunamadı");
                    }
                }
                else if (secim == "4")
                {
                    Console.WriteLine("Çıkış Yapılıyor");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz Seçim!");
                }
            }
        }
        static List<string> LoadTasks()
        {
            if (File.Exists(filePath))
                return new List<string>(File.ReadAllLines(filePath));
            return new List<string>();
        }

        static void SaveTasks(List<string> tasks)
        {
            File.WriteAllLines(filePath, tasks);
        }


    }

}
