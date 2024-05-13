﻿global using DevFreela.API.Filters;
global using DevFreela.Application.Commands.CreateComment;
global using DevFreela.Application.Commands.CreateProject;
global using DevFreela.Application.Commands.CreateUser;
global using DevFreela.Application.Commands.DeleteProject;
global using DevFreela.Application.Commands.FinishProject;
global using DevFreela.Application.Commands.LoginUser;
global using DevFreela.Application.Commands.StartProject;
global using DevFreela.Application.Commands.UpdateProject;
global using DevFreela.Application.InputModels;
global using DevFreela.Application.Queries.GetAllProjects;
global using DevFreela.Application.Queries.GetAllSkills;
global using DevFreela.Application.Queries.GetProjectById;
global using DevFreela.Application.Queries.GetUser;
global using DevFreela.Application.Validators;
global using DevFreela.Core.Repositories;
global using DevFreela.Core.Services;
global using DevFreela.Infrastructure.Auth;
global using DevFreela.Infrastructure.Persistence;
global using DevFreela.Infrastructure.Persistence.Repositories;
global using FluentValidation.AspNetCore;
global using MediatR;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.EntityFrameworkCore;
