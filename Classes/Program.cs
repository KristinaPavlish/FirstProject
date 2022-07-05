using Classes;
Console.WriteLine(TestTotalSalary());
Console.WriteLine(TestNameInitials());
Console.WriteLine(BoolTestTotalSalary()?"The salary is calculated correctly":"The salary is calculated incorrectly");

 Employee FirstInitiateClass()
{
    // init 1 class
    Employee employee = new Employee(null, 6, 7, 8);
    return employee;
}
Employee SecondInitiateClass()
{
    // init 2 class
    Employee employee = new Employee("Halushchynskyi Dmytro Ivanovych", 12, 7, 8);
    return employee;
}
Employee ThirdInitiateClass()
{
    // init 3 class
    Employee employee = new Employee("Ivasiuk Olena Igorovna", 23, 8, 8);
    return employee;
}

 
string TestTotalSalary()
{
    // tests for right calculation
    if (FirstInitiateClass().CalculationOfWages(45) == (7 * 45) - (7 * (45 * 0.2))
        && SecondInitiateClass().CalculationOfWages(45) == 277.2 //first calculating salary ( < hours ) 7 * 45 - 7 * 45 * 0,2 = 252
        //second calculating salary (10 > work exp < 20) 252 + 252 * 0.1 = 277.2
        && ThirdInitiateClass().CalculationOfWages(45) == (8 * 45) + (8 * (45 * 0.2))
       )
        return "The salary is calculated correctly";
    throw new Exception("The initials is calculated incorrectly");
}
 
bool BoolTestTotalSalary()
{
    // tests for right calculation
    return (FirstInitiateClass().CalculationOfWages(45) == (7 * 45) - (7 * (45 * 0.2))
            && SecondInitiateClass().CalculationOfWages(45) == 277.2
            //first calculating salary ( < hours ) 7 * 45 - 7 * 45 * 0,2 = 252
            //second calculating salary (10 > work exp < 20) 252 + 252 * 0.1 = 277.2
            && ThirdInitiateClass().CalculationOfWages(45) == (8 * 45) + (8 * (45 * 0.2)));


    // return "The salary is calculated correctly";
    //throw new NotImplementedException();
}

string TestNameInitials ()
 {
     // tests for right name initials
     if ( FirstInitiateClass().InitialsOfEmployee() == ""
          && SecondInitiateClass().InitialsOfEmployee() == "Halushchynskyi D.I." 
          && ThirdInitiateClass().InitialsOfEmployee() == "Ivasiuk O.I.")
     
         return "The initials is calculated correctly";

     throw new Exception("The initials is calculated incorrectly");

 }

