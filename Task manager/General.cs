using System;
using System.Collections.Generic;
using System.Linq;
namespace Task_manager
{
    class Interface
    {
        public static void Greatings()
        {
            Console.WriteLine("Welcome to the List manager");
            Options();
        }
        public static void Options()
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Add new task");
            Console.WriteLine("2. Mark task completed");
            Console.WriteLine("3. See all tasks");
            Console.WriteLine("4. Delete task");
            Console.WriteLine("5. Delete all task");
            Console.WriteLine("6. Mark all task down");
            Console.WriteLine("7. Exit");
            try
            {
                int option = Convert.ToInt32(Console.ReadLine());
                DirectToAction(option);

            } catch(FormatException)
            {
                Console.WriteLine("You choosed wrong option");
                Console.WriteLine("Press any button to continue");
                Console.ReadLine();
                Options();
            }
        }
        public static void DirectToAction(int option)
        {
            if(option< 1 || option > 7)
            {
                Console.WriteLine("This is not an option");
                Console.WriteLine("Press any button to continue");
                Console.ReadLine();
                Options();
            }
            if (option == 1) AddTask();
            if (option == 3) allTask();
            if (option == 4 || option == 2) ChoseTask(option);
            if (option == 5 || option == 6) ChooseAll(option);
            if (option == 7) Environment.Exit(0);
        }
        public static void AddTask()
        {
            string name = " ";
            try
            {
                Console.WriteLine("Enter Task name:");
                name = Console.ReadLine();
            } catch(FormatException)
            {
                Console.WriteLine("Invalid name");
                Console.WriteLine("Press any button to continue");
                Console.ReadLine();
                AddTask();
            }
            string DeadLine = "";
            try
            {
                int DeadLineOption = DateOption();
                if (DeadLineOption == 1) DeadLine = EnterDate();
            } catch
            {
                Console.WriteLine("Invalid date");
                Console.WriteLine("Press any button to continue");
                Console.ReadLine();
                AddTask();
            }
            Task TaskObject =new Task(name, DeadLine);
            TasksContainer.AddTaskToList(TaskObject);
            Console.WriteLine("Added your task");
            Console.WriteLine("Press any button to continue");
            Console.ReadLine();
            Options();
        }
        public static dynamic DateOption()
        {
                Console.WriteLine("Choose option:");
                Console.WriteLine("1. Task with deadline");
                Console.WriteLine("2. Task without deadline");
                return Convert.ToInt32(Console.ReadLine());
        }
        public static string EnterDate()
            {
            Console.WriteLine("Enter date in YYY-MM-DD");
            string date = Console.ReadLine();
            return date;
        }
        public static void allTask()
        {
            try
            {
                Console.WriteLine("This is your list:");
                TasksContainer.showAllList();
                Console.WriteLine("Press any button to cotinue");
                Console.ReadLine();
                Options();
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
                Console.WriteLine("You don't have tasks");
                Console.WriteLine("Press any button to continue");
                Console.ReadLine();
                Options();
            }
        }
        public static void ChoseTask(int option)
        {
            try
            {
                Console.WriteLine("Choose task:");
                TasksContainer.showAllList();
            } catch
            {
                Console.WriteLine("You don't have tasks");
                Console.WriteLine("Press any button to cotinue");
                Console.ReadLine();
                Options();
            }
            try
            {
                int TaskIndex = Convert.ToInt32(Console.ReadLine());
                List<Task> tasks = TasksContainer.getList();
                if (tasks.Count < TaskIndex || TaskIndex <= 0)
                {
                    Console.WriteLine("This is not an option");
                    Console.WriteLine("Press any button to cotinue");
                    Console.ReadLine();
                    ChoseTask(option);
                }
                if (option == 2) CheckTask(TaskIndex - 1);
                if (option == 4) deleteTask(TaskIndex - 1);

            } catch
            {
                Console.WriteLine("This was not a number");
                Console.WriteLine("Press any button to cotinue");
                Console.ReadLine();
                ChoseTask(option);
            }
            
        }
        public static void CheckTask(int index)
        {
            List<Task>  tasks = TasksContainer.getList();
            if (tasks[index].complited) tasks[index].complited = false;
            else tasks[index].complited = true;
            TasksContainer.addToJsonFile(tasks);
            Console.WriteLine("Edited your task");
            Console.WriteLine("Press any button to cotinue");
            Console.ReadLine();
            Options();
        }
        public static void deleteTask(int TaskIndex)
        {
            
            try
            {
            List<Task> tasks = TasksContainer.getList();
            tasks = tasks.Select((el, index) => new { Task = el, Index = index })
            .Where((item => item.Index != TaskIndex))
            .Select(item => item.Task)
            .ToList();
            TasksContainer.addToJsonFile(tasks);
                Console.WriteLine("Deleted task sucesfuly");
                Console.WriteLine("Press any button to continue");
                Console.ReadLine();
                Options();
            } catch
            {
                Console.WriteLine("You don't have tasks");
                Console.WriteLine("Press any button to cotinue");
                Console.ReadLine();
                Options();
            }
        }
        public static void ChooseAll(int option)
        {
            if (option == 5) DeleteAllTask();
            if (option == 6) CheckAllTasks();
            Console.WriteLine("Press any button to continue");
            Console.ReadLine();
            Options();
        }
        public static void DeleteAllTask()
        {
            try
            {
            List<Task> tasks = TasksContainer.getList();
            tasks.Clear();
            TasksContainer.addToJsonFile(tasks);
                Console.WriteLine("Deleted all sucesfuly");
                Console.WriteLine("Press any button to cotinue");
                Console.ReadLine();
                Options();
            } catch
            {
                Console.WriteLine("You don't have task to delete");
                Console.WriteLine("Press any button to continue");
                Console.ReadLine();
                Options();
            }

        }
        public static void CheckAllTasks()
        {
            try
            {
                List<Task> tasks = TasksContainer.getList();
                for (int i = 0; i < tasks.Count; i++)
                {
                    tasks[i].complited = true;
                }
                TasksContainer.addToJsonFile(tasks);
                Console.WriteLine("Checked all tasks");
                Console.WriteLine("Press any button to cotinue");
                Console.ReadLine();
                Options();
            }
            catch
            {
                Console.WriteLine("You don't have tasks to check");
                Console.WriteLine("Press any button to continue");
                Console.ReadLine();
                Options();
            }
        }
        public static void Main()
        {
            Greatings();
        }
    }
}

