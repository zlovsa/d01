using System;
using System.Collections.Generic;
using d01_ex01;

List<Task> tasks = new List<Task>();

void AddTask() {
	Console.WriteLine("> Введите заголовок");
	var title = Console.ReadLine();
	Console.WriteLine("> Введите описание");
	var summary = Console.ReadLine();
	Console.WriteLine("> Введите срок");
	var dueDateStr = Console.ReadLine();
	Console.WriteLine("> Введите тип");
	var typeStr = Console.ReadLine();
	Console.WriteLine("> Установите приоритет");
	var priorityStr = Console.ReadLine();
	DateTime dueDate = default;
	TaskType type;
	TaskPriority priority = TaskPriority.Normal;
	if (title.Length == 0
		|| dueDateStr.Length > 0 && !DateTime.TryParse(dueDateStr, out dueDate)
		|| !Enum.TryParse(typeStr, out type)
		|| priorityStr.Length > 0 && !Enum.TryParse(priorityStr, out priority)) {
		Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
		return;
	}
	DateTime? nullDate = null;
	if (dueDateStr.Length > 0 && DateTime.TryParse(dueDateStr, out dueDate))
		nullDate = dueDate;
	var newTask = new Task(title, summary, nullDate, type, priority);
	tasks.Add(newTask);
	Console.WriteLine($"{newTask}");
}

void ListTasks() {
	if (tasks.Count == 0)
		Console.WriteLine("Список задач пока пуст.");
	else
		foreach (var task in tasks)
			Console.WriteLine($"{task}");
}

void DoneTask() {
	Console.WriteLine("> Введите заголовок");
	var title = Console.ReadLine();
	foreach(var task in tasks)
		if (task.title == title) {
			if (task.Done())
				Console.WriteLine($"Задача [{task.title}] выполнена!");
			else
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
			return;
		}
	Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
}

void WontdoTask() {
	Console.WriteLine("> Введите заголовок");
	var title = Console.ReadLine();
	foreach (var task in tasks)
		if (task.title == title) {
			if (task.Wontdo())
				Console.WriteLine($"Задача [{task.title}] более не актуальна!");
			else
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
			return;
		}
	Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
}

Console.Write("> ");
string command;
while ((command = Console.ReadLine()) != null) {
	switch (command) {
		case "quit":
		case "q":
			return;
		case "add":
			AddTask();
			break;
		case "list":
			ListTasks();
			break;
		case "done":
			DoneTask();
			break;
		case "wontdo":
			WontdoTask();
			break;
		default:
			Console.WriteLine("Доступные команды: add list done wontdo quit q");
			break;
	}
	Console.Write("> ");
}