﻿namespace EmpManagementSystemAPI.Models
{
    public class EmployeeDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public bool AssignedToWorkStreams { get; set; }
    }
}
