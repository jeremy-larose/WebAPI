﻿using System;

namespace WebAPI.DTOs.Email
{
    public record EmailDTO
    {
        public Guid Id { get; init; }
        public string FromDisplayName { get; init; }
        public string ToDisplayName { get; init; }
        public string FromAddress { get; init; }
        public string ToAddress { get; init; }
        public string Subject { get; init; }
        public string Body { get; init; }
        public DateTimeOffset? LastContactDate { get; init; }
    }
}