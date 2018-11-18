using Sharp2POC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp2POC.Core.Repositories.Interfaces
{
	public interface ISQLSampleRepository
	{
		List<SQLExampleObject> ReturnList();
		void Add(SQLExampleObject sampleobj);
		void Remove(SQLExampleObject sampleobj);
		void GenerateSampleList();
		void EraseList();
	}
}
