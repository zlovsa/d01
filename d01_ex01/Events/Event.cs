using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex01
{
	record Event
	{
		public DateTime date = DateTime.Now;
		public TaskState state;
		public Event(TaskState state) {
			this.state = state;
		}
	}
}
