using management.Contexts;

namespace management.Employees.EmployeeCodeGenerate
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
                var employees = dataContext.Employees.ToList();

                bool go = true;
                string newCode = "E" + randomCode.Next(10000, 100000);

                while (go)
                {
                    int lastCode = 0;

                    foreach (var employe in employees)
                    {
                        if (employe.EmployeeCode == newCode)
                        {
                            do
                            {
                                newCode = "E" + randomCode.Next(10000, 100000);

                            } while (employe.EmployeeCode != newCode);
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
}




