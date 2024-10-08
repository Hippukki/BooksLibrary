﻿using Domain.Abstractions;
using MediatR;

namespace Application.Books.Commands.DeleteBook;
public record DeleteBookCommand(int Id) : IRequest<Result>;
