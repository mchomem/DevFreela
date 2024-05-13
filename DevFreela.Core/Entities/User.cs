﻿namespace DevFreela.Core.Entities;

public class User : BaseEntity
{
    public User(string fullName, string email, DateTime birthDate, string password, string role)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        CreatedAt = DateTime.Now;
        Active = true;
        Password = password;
        Role = role;
        Skills = new List<UserSkill> { };
        OwnedProjects = new List<Project> { };
        FreeLanceProjects = new List<Project> { };
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Active { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
    public List<UserSkill> Skills { get; private set; }
    public List<Project> OwnedProjects { get; private set; }
    public List<Project> FreeLanceProjects { get; private set; }
    public List<ProjectComment> Comments { get; private set; }

    public void ChangePassword(string password)
    {
        Password = password;
    }
}
