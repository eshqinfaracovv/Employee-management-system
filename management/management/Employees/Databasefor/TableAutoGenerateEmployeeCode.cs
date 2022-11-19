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
                _empCode = "E" + randomCode.Next(10000, 100000);
                return _empCode;

            }

        }
    }
}
