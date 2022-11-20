using management.Employees.Contexts;

namespace management.Employees.Databasefor
{
    public class TableAutoGenerateEmployeeCode
    {
         static Random randomCode = new Random();

        private static string _empCode;
        public static string RandomEmpCode
        {
            get
            {
                //_empCode = "E" + randomCode.Next(10000, 100000);
                //return _empCode;

				DataContext dataContext = new DataContext();
				var employees = dataContext.Employes.ToList();

				bool go = true;
				string newCode = "E" + _random.Next(10000, 100000);

				while (go)
				{
					int lastCode = 0;

					foreach (var employe in employees)
					{
						if (employe.EmployesCode == newCode)
						{
							do
							{
								newCode = "E" + _random.Next(10000, 100000);

							} while (employe.EmployesCode != newCode);
						}
						lastCode++;

					}
					if (lastCode == employees.Count)
					{
						go = false;
					}
				}
				return newCode;



			}

        }
    }




