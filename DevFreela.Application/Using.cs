﻿global using DevFreela.Application.Commands.CreateComment;
global using DevFreela.Application.Commands.CreateProject;
global using DevFreela.Application.Commands.CreateUser;
global using DevFreela.Application.ViewModels;
global using DevFreela.Core.DTOs;
global using DevFreela.Core.Entities;
global using DevFreela.Core.IntegrationEvents;
global using DevFreela.Core.Repositories;
global using DevFreela.Core.Services;
global using FluentValidation;
global using MediatR;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using RabbitMQ.Client;
global using RabbitMQ.Client.Events;
global using System.Text;
global using System.Text.Json;
global using System.Text.RegularExpressions;
