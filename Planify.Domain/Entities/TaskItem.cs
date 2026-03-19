using System;
using System.Collections.Generic;
using System.Text;

namespace Planify.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public bool Completed { get; set; }
}