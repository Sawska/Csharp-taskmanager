using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Task_manager
{
	public class TasksContainer
	{
        public static void AddTaskToList(Task obj)
		{
			try
			{
                List<Task> tasks = getList();
                tasks.Add(obj);
                addToJsonFile(tasks);
            } catch
			{
				List<Task> tasks = new List<Task>();
				tasks.Add(obj);
				addToJsonFile(tasks);
			}
		}
		 public static List<Task> getList()
		{
			string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Tasks.json");
			string jsonString = File.ReadAllText(filePath);
			List <Task> tasks = JsonSerializer.Deserialize<List<Task>>(jsonString);
			return tasks;
		}
		public static void addToJsonFile(List<Task> tasks)
		{
			string jsonString = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Tasks.json");
            File.WriteAllText(filePath, jsonString);
		}
		public static void showAllList()
		{
			List<Task> tasks = getList();
			for(int i = 0;i<tasks.Count; i++)
			{
				string check  = "";
				if (tasks[i].complited) check = "[✓]";
				else check = "[ ]";
                Console.WriteLine($"{check} {i + 1}. {tasks[i].name} {tasks[i].DeadLine}");
			}
		}
		public static bool CheckIfDeadLinePassed(Task el)
		{
			return Convert.ToDateTime(el.DeadLine) < DateTime.Now;
		}
    }
}

