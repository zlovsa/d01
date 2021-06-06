using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex01
{
	class Task
	{
		public Task(string title,string summary,DateTime? dueDate,TaskType type,TaskPriority priority) {
			this.title = title;
			this.summary = summary;
			this.dueDate = dueDate;
			this.type = type;
			this.priority = priority;
			history = new List<Event>();
			history.Add(new CreatedEvent());
		}

		public string title { get; }
		string summary;
		DateTime? dueDate;
		TaskType type;
		TaskPriority? priority = TaskPriority.Normal;
		public TaskState state => history[^1].state;
		List<Event> history;

		public bool Done() {
			if (state != TaskState.New)
				return false;
			history.Add(new TaskDoneEvent());
			return true;
		}

		public bool Wontdo() {
			if (state != TaskState.New)
				return false;
			history.Add(new TaskWontDoEvent());
			return true;
		}

		public override string ToString() {
			string result = $"{title}{Environment.NewLine}[{type}] [{state}]{Environment.NewLine}Priority: {priority}";
			if (dueDate != null)
				result += $", Due till {dueDate:d}";
			result += $"{Environment.NewLine}{summary}";
			return result;
		}
	}
}
