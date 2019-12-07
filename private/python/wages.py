def wages(hourly_wages, number_of_hours_worked, employee_type):
    wages = hourly_wages * number_of_hours_worked
        
    if (number_of_hours_worked > 40 and employee_type == "Fulltime"):
        wages = wages + (number_of_hours_worked - 40) * 1.5 * hourly_wages
            
    return(wages)  

