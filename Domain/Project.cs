﻿namespace Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }

    }
}
