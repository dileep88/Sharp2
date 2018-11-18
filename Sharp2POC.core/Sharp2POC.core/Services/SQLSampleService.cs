using Sharp2POC.Core.Models;
using Sharp2POC.Core.Repositories.Interfaces;
using Sharp2POC.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp2POC.Core.Services
{
	//Services allow the user to interact with the repository and also provide a chance to 
	//alter incoming and outgoing data from the database before displaying or saving the data.
	public class SQLSampleService : ISQLSampleService
	{
		private readonly ISQLSampleRepository sqlRepo;

		public SQLSampleService(ISQLSampleRepository _sqlRepo)
		{
			sqlRepo = _sqlRepo;
		}
		public void Add(SQLExampleObject sampleobj)
		{
			sqlRepo.Add(sampleobj);
		}

		public void Remove(SQLExampleObject sampleobj)
		{
			sqlRepo.Remove(sampleobj);
		}

		public List<SQLExampleObject> ReturnList()
		{
			return sqlRepo.ReturnList();
		}

		public void GenerateSampleList()
		{
			sqlRepo.GenerateSampleList();
		}

		public void EraseList()
		{
			sqlRepo.EraseList();
		}
	}
}
