using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d01_ex01
{
	record TaskDoneEvent() : Event(TaskState.Done);
}
