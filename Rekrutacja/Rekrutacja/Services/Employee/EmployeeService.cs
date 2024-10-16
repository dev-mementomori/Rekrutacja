using Rekrutacja.Interfaces.Services;
using Soneta.Business;
using Soneta.Kadry;
using System;
using System.Collections.Generic;
using Soneta.Types;

namespace Rekrutacja.Services.Employee
{
    public interface IEmployeeService : IContextualService
    {
        IEnumerable<Pracownik> GetEmployeesFromContext();
        void SaveResultForEmployees(IEnumerable<Pracownik> employees, double result, Date dateOfCalculation);
    }
    public class EmployeeService : IEmployeeService
    {
        public Context Context { get; private set; }

        public void SetContext(Context context)
        {
            Context = context;
        }
        public IEnumerable<Pracownik> GetEmployeesFromContext()
        {
            return (Pracownik[])Context[typeof(Pracownik[])] ?? Array.Empty<Pracownik>();
        }
        public void SaveResultForEmployees(IEnumerable<Pracownik> employees, double result, Date dateOfCalculation)
        {
            using (Session session = Context.Login.CreateSession(false, false, "ModyfikacjaPracownika"))
            {
                using (ITransaction trans = session.Logout(true))
                {
                    foreach (var employee in employees)
                    {
                        var employeeSession = session.Get(employee);
                        employeeSession.Features["Wynik"] = result;
                        employeeSession.Features["DataObliczen"] = dateOfCalculation;
                    }
                    trans.CommitUI();
                }
                session.Save();
            }
        }
    }
}
