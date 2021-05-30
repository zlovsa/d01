using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex01.Tasks
{
	class Task
	{
		public string title;
		public string summary;
		public DateTime dueDate;
		public TaskType type;
		public TaskPriority priority = TaskPriority.Normal;
	}
}
