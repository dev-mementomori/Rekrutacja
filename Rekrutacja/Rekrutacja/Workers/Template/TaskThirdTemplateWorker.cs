﻿
using Soneta.Business;
using System;
using System.Linq;
using Soneta.Kadry;
using Soneta.Types;
using Rekrutacja.Workers;
using Rekrutacja.Factories.Services;
using Rekrutacja.Services.Employee;
using Rekrutacja.Enums.Calculator;
using Rekrutacja.Factories.Operations;
using System.Collections.Generic;
using Rekrutacja.Factories.Areas;
using Rekrutacja.Helper;


//Rejetracja Workera - Pierwszy TypeOf określa jakiego typu ma być wyświetlany Worker, Drugi parametr wskazuje na jakim Typie obiektów będzie wyświetlany Worker
[assembly: Worker(typeof(TaskThirdTemplateWorker), typeof(Pracownicy))]

namespace Rekrutacja.Workers
{

    public class TaskThirdTemplateWorker
    {
        // Definicja parametrów Workera
        public class CalculatorWorkerParams : ContextBase
        {
            [Caption("Zmienna A")]
            public string  ZmiennaA { get; set; }

            [Caption("Figura")]
            public FigureType Figura { get; set; }

            [Caption("Zmienna B")]
            public string ZmiennaB { get; set; }

            [Caption("Data obliczeń")]
            public Date DataObliczen { get; set; }

            public CalculatorWorkerParams(Context context) : base(context)
            {
                Figura = FigureType.None;
                DataObliczen = DateTime.Today;
            }
        }

        [Context]
        public Context Cx { get; set; }

        [Context]
        public CalculatorWorkerParams Parametry { get; set; }

        private IEmployeeService _employeeService;
        public TaskThirdTemplateWorker(Context context)
        {
           context.Session.GetService<IServiceFactory>(out IServiceFactory serviceFactory);

            _employeeService = serviceFactory.Get<EmployeeService>(context);
            
        }

        [Action("Kalkulator - zadanie 3",
            Description = "Prosty kalkulator",
            Priority = 10,
            Mode = ActionMode.ReadOnlySession,
            Icon = ActionIcon.Accept,
            Target = ActionTarget.ToolbarWithText)]
        public void ExecuteAction()
        {
            //Pobieramy wybranych pracownikow

            IEnumerable<Pracownik> employees = _employeeService.GetEmployeesFromContext();
            if (!employees.Any())
            {
                throw new InvalidOperationException("Nie wybrano żadnych pracowników.");
            }

            //Wykonujemy obliczenia
            double result =  AreasFactory.GetFigure(Parametry.Figura)
                .CalculateArea(ParseHelper.MyIntParse(Parametry.ZmiennaA), ParseHelper.MyIntParse(Parametry.ZmiennaB));

            //Zapisujemy wyniki do wybranych pracownikow
             _employeeService.SaveResultForEmployees(employees, (int)result, Parametry.DataObliczen);
        }
    }
}